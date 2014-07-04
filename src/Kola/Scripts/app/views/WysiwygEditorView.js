define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var WysiwygComponentView = require('app/views/WysiwygComponentView');
    var Template = require('text!app/templates/WysiwygEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
            _.bindAll(this, 'buildChildren');
        },

        refresh: function () {
            var self = this;
            var url = '/_kola/preview/nelly';

            var $html = $(this.$('iframe').contents()).find('html');

            $.ajax({
                url: url,
                dataType: 'html'
            }).done(function (data) {

                $html.html(data)
                self.buildChildren($html);
            })
        },

        render: function () {
            var self = this;
            this.$el.html(this.template());

            var $iframe = this.$('iframe');

            $iframe.load(function () {
                var $html = $($iframe.contents()).find('html');
                self.buildChildren($html);
            });

            $iframe.attr('src', '/_kola/preview/nelly');

            return this;
        },

        buildChildren: function ($html) {
            var self = this;
            self.model.get('components').each(function (component) {
                var $elements = self.findElements($html.contents(), component.get('path'));

                var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                wysiwygComponentView.render();
            });
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
                    if (childNodes && childNodes.length > 0) {
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