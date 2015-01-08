define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var Template = require('text!app/templates/PropertyTemplate.html');
    var parameterEditors = require('parameterEditors');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function () {
            this.editMode = false;
        },

        events: {
            'click .value': 'edit'
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

            var parameter = this.model;
            var editorInfo = this.getEditorInfo(this.model.type);
            var $child = this.$el.find('.value').last();

            if (this.editorView) {
                this.editorView.remove();
            }

            if (editorInfo) {
                require([editorInfo.url], function (EditorView) {
                    self.editorView = new EditorView({
                        model: parameter,
                        el: $child
                    });
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

        getEditorInfo: function (parameterType) {
            return _.find(parameterEditors, function (parameterEditor) {
                return parameterEditor.name == parameterType;
            });
        }
    });
});