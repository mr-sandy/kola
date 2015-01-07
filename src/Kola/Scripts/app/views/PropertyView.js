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

        events: {
            'click .value': 'edit'
        },

        render: function (editMode) {
            var self = this;

            this.$el.append(this.template(this.model));

            var $child = this.$el.find('.value').last();

            var parameter = this.model;
            var editor = _.find(parameterEditors, function (parameterEditor) { return parameterEditor.name == parameter.type; });

            if (editor) {
                require([editor.url], function (EditorView) {
                    var editorView = new EditorView({
                        model: parameter,
                        el: $child
                    });
                    editorView.render(editMode);
                });
            }

            return this;
        },

        edit: function (e) {
            this.render(true);
        }
    });
});