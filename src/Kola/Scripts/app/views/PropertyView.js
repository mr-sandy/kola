define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var Template = require('text!app/templates/PropertyTemplate.html');
    var propertyEditors = require('propertyEditors');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.editMode = false;
            this.amendments = options.amendments;
            this.componentPath = options.componentPath;
        },

        events: {
            'click': 'edit'
        },

        render: function () {
            var self = this;

            var context = _.extend(this.model, { editMode: this.editMode });

            this.$el.html(this.template(context));

            this.loadEditor().then($.proxy(this.renderEditor, this));

            return this;
        },

        edit: function (e) {
            if (!this.editMode) {
                this.editMode = true;
                this.render();
            }
        },

        loadEditor: function () {
            var self = this;
            var d = $.Deferred();

            var property = this.model;
            var editorInfo = this.getEditorInfo(this.model.type);
            var $child = this.$el.find('.value form').last();

            if (this.editorView) {
                this.editorView.remove();
            }

            if (editorInfo) {
                require([editorInfo.url], function (EditorView) {
                    self.editorView = new EditorView({
                        model: property,
                        el: $child
                    });
                    self.editorView.on('submit', self.submit, self)
                    d.resolve();
                });
            }
            else {
                d.resolve();
            }

            return d.promise();
        },

        renderEditor: function () {
            if (this.editorView) {
                this.editorView.render(this.editMode);
            }
        },

        getEditorInfo: function (propertyType) {
            return _.find(propertyEditors, function (propertyEditor) {
                return propertyEditor.name == propertyType;
            });
        },

        submit: function () {
            if (this.editMode) {
                this.editMode = false;

                if (this.editorView.value() !== this.model.value.value) {
                    this.amendments.setProperty({
                        propertyName: this.model.name,
                        componentPath: this.componentPath,
                        value: this.editorView.value()
                    });
                }
                else {
                    this.render();
                }
            }
        }
    });
});