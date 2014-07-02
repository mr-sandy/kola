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
                    var $elements = self.findElements($iframe.contents().find('body'), component.get('path'));

                    var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });
                });
            });

            $iframe.attr('src', '/_kola/preview/nelly');

            return this;
        },

        findElements: function (rootElement, componentPath) {
            var add = false;
            var elements = [];

            _.each(rootElement.contents(), function (el, i) {
                if (el.nodeType == 8 && el.nodeValue == componentPath + '-start') {
                    add = true;
                }

                if (add) {
                    elements.push(el);
                }

                if (el.nodeType == 8 && el.nodeValue == componentPath + '-end') {
                    add = false;
                }
            });

            return $(elements);
        }
    });
});