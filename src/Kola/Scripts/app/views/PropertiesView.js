define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var Template = require('text!app/templates/PropertiesTemplate.html');
    var PropertyTemplate = require('text!app/templates/PropertyTemplate.html');
    var parameterEditors = require('parameterEditors');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),
        childTemplate: Handlebars.compile(PropertyTemplate),

        initialize: function (options) {
            this.stateBroker = options.stateBroker;
            this.listenTo(options.stateBroker, 'change', this.render);
        },

        render: function () {
            var self = this;

            var model = this.stateBroker.selected ? this.stateBroker.selected.toJSON() : {};
            this.$el.html(this.template(model));

            if (this.stateBroker.selected) {
                var $table = this.$('tbody').first();

                _.each(model.parameters, function (parameter) {

                    var $child = $table.append(self.childTemplate(parameter)).find('tr').last();

                    var editor = _.find(parameterEditors, function (parameterEditor) { return parameterEditor.name == parameter.type; });

                    if (editor) {
                        require([editor.url], function (EditorView) {
                            var editorView = new EditorView({
                                model: parameter,
                                el: $child
                            });
                            editorView.render();
                            editorView.on('change', function (e) {
                                alert(e);
                            });
                        });
                    }
                });
            }

            return this;
        }
    });
});