define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var domHelper = require('app/views/DomHelper');

    return Backbone.View.extend({

        events: {
            'mouseover': 'handleMouseover',
            'mouseout': 'handleMouseout',
            'click': 'handleClick'
        },

        initialize: function (options) {
            this.fullRefresh = options.fullRefresh;
            this.mask = options.mask;

            this.listenTo(this.model, 'sync', this.handleSync);
            this.listenTo(this.model, 'active', this.showActive);
            //            this.listenTo(this.model, 'inactive', this.showInactive);
            this.listenTo(this.model, 'selected', this.showSelected);
            this.listenTo(this.model, 'deselected', this.showDeselected);

            this.children = [];
            this.setElement(domHelper.findDirectlyOwned(options.$html));
            this.buildChildren(options.$html);
        },

        handleSync: function (model, response, options) {
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
                    this.children.push(new WysiwygComponentView({ model: component, $html: $elements, fullRefresh: this.fullRefresh, mask: this.mask }));
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

        handleMouseover: function (e) {
            e.stopPropagation();
            this.model.activate();
        },

        handleMouseout: function (e) {
            e.stopPropagation();
            this.model.deactivate();
        },

        handleClick: function (e) {
            e.stopPropagation();
            this.model.toggleSelected();
        },

        findBounds: function (coords) {

            coords = coords || { top: null, bottom: null, left: null, right: null };

            _.each(this.$el, function (node) {
                if (node.nodeType == 1 && $(node).is(":visible")) {
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
                child.findBounds(coords);
            });

            return coords;
        },

        showActive: function () {
            this.mask.highlight(this.findBounds());
        },

        showSelected: function () {
            //this.mask.select(this.findBounds());
        },

        showDeselected: function () {
            //this.mask.deselect();
        }
    });
});