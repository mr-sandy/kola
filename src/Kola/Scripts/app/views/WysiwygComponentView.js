define(function (require) {
    "use strict";

    var Backbone = require('backbone');

    return Backbone.View.extend({

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);
        },

        events: {
            "mouseover": "activate",
            "mouseout": "deactivate"
        },

        refresh: function () {
            var self = this;
            var url = '/_kola/preview/nelly?componentPath=' + this.model.get('path');

            $.ajax({
                url: url,
                dataType: 'html'
            }).done(function (data) {
                self.$el.empty();
                self.$el.append(data);
                self.render();
            })
        },

        render: function () {
            var self = this;
            var WysiwygComponentView = require('app/views/WysiwygComponentView');

            var children = this.model.get('components') || this.model.get('areas');

            if (children) {
                children.each(function (component) {
                    var $elements = self.findElements(self.$el, component.get('path'));

                    var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                    wysiwygComponentView.render();
                });
            }
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
        },

        showActive: function () {
            this.$el.css({ "background-color": "#ccc" });
        },

        showInactive: function () {
            this.$el.css({ "background-color": "transparent" });
        },

        activate: function (e) {
            this.model.trigger('active');
            e.stopPropagation();
        },

        deactivate: function (e) {
            this.model.trigger('inactive');
            e.stopPropagation();
        }
    });
});