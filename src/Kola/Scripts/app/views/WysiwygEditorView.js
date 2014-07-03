define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var WysiwygComponentView = require('app/views/WysiwygComponentView');
    var Template = require('text!app/templates/WysiwygEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            var self = this;
            this.$el.html(this.template());

            var $iframe = this.$('iframe');

            $iframe.load(function () {

                self.model.get('components').each(function (component) {
                    var $elements = self.findElements($iframe.contents().find('body').contents(), component.get('path'));

                    var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                    wysiwygComponentView.render();
                });
            });

            $iframe.attr('src', '/_kola/preview/nelly');

            return this;
        },

        findElements: function (nodes, componentPath) {
            var select = false;
            var selected = [];

            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];

                if (node.nodeType == 8 && node.nodeValue == componentPath + '-start') {
                    select = true;
                }

                if (select) {
                    selected.push(node);
                }
                else {
                    var childNodes = node.childNodes;
                    if (childNodes) {
                        var childResult = this.findElements(childNodes, componentPath);

                        if (childResult.length > 0) {
                            return childResult;
                        }
                    }
                }

                if (node.nodeType == 8 && node.nodeValue == componentPath + '-end') {
                    select = false;
                }
            }

            return $(selected);
        }
    });
});