define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var domHelper = require('app/views/DomHelper');

    return Backbone.View.extend({

        events: {
            'mouseover': 'activate',
            'mouseout': 'deactivate',
            'click': 'select'
        },

        initialize: function (options) {
            this.stateBroker = options.stateBroker;
            this.fullRefresh = options.fullRefresh;

            this.listenTo(this.model, 'sync', this.handleSync);
            this.listenTo(this.model, 'active', this.showActive);
            this.listenTo(this.model, 'selected', this.showSelected);

            this.mask = options.mask;

            this.children = [];

            this.setElement(domHelper.findDirectlyOwned(options.$html));
            this.buildChildren(options.$html);
        },

        handleSync: function (model, response, options) {

            // don't bother doing anything if we're just been getting an up-to-date property list
            if (!(options.propertyListRefresh || false)) {

                // if the element is not inside the body tag, we need to reload the whole page
                if (this.$el.parents('body').length === 0) {
                    this.fullRefresh();
                }
                else {
                    $.ajax({
                        url: this.model.previewUrl,
                        dataType: 'html',
                        context: this
                    }).done(this.refresh);
                }
            }
        },

        refresh: function (html) {

            var $html = $(html);
            domHelper.replace(this.$el[0], this.$el[this.$el.length - 1], $html);

            this.setElement(domHelper.findDirectlyOwned($html));
            this.buildChildren($html);
        },

        buildChildren: function ($html) {

            this.destroyChildren();

            var childComponents = this.model.get('components') || this.model.get('areas');

            if (childComponents) {

                var WysiwygComponentView = require('app/views/WysiwygComponentView');

                childComponents.each(function (component) {
                    var $elements = domHelper.findElements($html, component.get('path'));
                    this.children.push(new WysiwygComponentView({ model: component, $html: $elements, mask: this.mask, stateBroker: this.stateBroker, fullRefresh: this.fullRefresh }));
                }, this);
            }
        },

        destroyChildren: function () {
            var child;
            while (child = this.children.pop()) {
                child.destroy();
            }
        },

        destroy: function () {
            // don't do a backbone .remove, because that also removes the dom elements 
            // we'll remove the dom elements ourselves once we've inserted the replacements nodes
            this.destroyChildren();
            this.stopListening();
            this.setElement(null);
        },

        activate: function (e) {
            e.stopPropagation();
            this.stateBroker.highlight(this.model);
        },

        deactivate: function (e) {
            e.stopPropagation();
            this.stateBroker.unhighlight(this.model);
        },

        select: function (e) {
            e.stopPropagation();
            this.stateBroker.select(this.model);
        },

        stretchCoords: function (coords) {

            coords = coords || { top: null, bottom: null, left: null, right: null };

            _.each(this.$el, function (node) {
                if (node.nodeType == 1) {
                    var $node = $(node);
                    var offset = $node.offset();

                    if (offset.top < coords.top || coords.top == null) {
                        coords.top = offset.top;
                    }

                    if (offset.left < coords.left || coords.left == null) {
                        coords.left = offset.left;
                    }

                    var bottom = offset.top + $node.outerHeight();
                    if (bottom > coords.bottom || coords.bottom == null) {
                        coords.bottom = bottom;
                    }

                    var right = offset.left + $node.outerWidth();
                    if (right > coords.right || coords.right == null) {
                        coords.right = right;
                    }
                }
            });

            _.each(this.children, function (child) {
                child.stretchCoords(coords);
            });

            return coords;
        },

        showActive: function () {
            this.mask.set(this.stretchCoords());
        },

        showSelected: function () {
            var top = _.reduce(this.$el, function (memo, node) {
                return node.nodeType != 8 ? _.max([$(node).offset().top, memo]) : memo;
            }, 0);

            this.$el.closest('body').animate({ scrollTop: top }, 600);
        }
    });
});