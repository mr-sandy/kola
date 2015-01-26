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
            var $editorElement = this.$el.find('.value').last();

            this.loadEditor($editorElement).then($.proxy(this.renderEditor, this));

            return this;
        },

        edit: function (e) {
            if (!this.editMode) {
                this.editMode = true;
                this.render();
            }
        },

        loadEditor: function ($editorElement) {
            var self = this;
            var d = $.Deferred();

            var property = this.model;
            var editorInfo = this.getEditorInfo(this.model.type);

            if (this.editorView) {
                this.editorView.setElement($editorElement);
                d.resolve();
            }
            else 
            if (editorInfo) {
                require([editorInfo.url], function (EditorView) {
                    self.editorView = new EditorView({
                        model: property,
                        el: $editorElement
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

        submit: function (e) {
            if (e) {
                e.preventDefault();
            }

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