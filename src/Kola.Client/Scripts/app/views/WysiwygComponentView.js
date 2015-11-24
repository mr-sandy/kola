define(function (require) {
    "use strict";

    // ReSharper disable InconsistentNaming

    var Backbone = require('backbone');
    var domHelper = require('app/views/DomHelper');

    // ReSharper restore InconsistentNaming

    return Backbone.View.extend({

        events: {
            'mouseover': 'handleMouseover',
            'mouseout': 'handleMouseout',
            'click': 'handleClick'
        },

        initialize: function (options) {
            this.fullRefresh = options.fullRefresh;
            this.maskView = options.maskView;
            this.previewUrl = options.previewUrl;

            this.listenTo(this.model, 'sync', this.handleSync);
            this.listenTo(this.model, 'active', this.showActive);
            //            this.listenTo(this.model, 'inactive', this.showInactive);
            this.listenTo(this.model, 'selected', this.showSelected);
            this.listenTo(this.model, 'deselected', this.showDeselected);

            this.children = [];
            this.setElement(domHelper.findDirectlyOwned(options.$html));
            this.buildChildren(options.$html);
        },

        handleSync: function () {
            // if the element is not inside the body tag, we need to reload the whole page
            if (this.$el.parents('body').length === 0) {
                this.fullRefresh();
            }
            else {
                $.ajax({
                    url: this.previewUrl + '&componentPath=' + this.model.get('path'),
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

                // ReSharper disable once InconsistentNaming
                var WysiwygComponentView = require('app/views/WysiwygComponentView');

                childComponents.each(function (component) {
                    var $elements = domHelper.findElements($html, component.get('path'));
                    this.children.push(new WysiwygComponentView({
                        model: component,
                        previewUrl : this.previewUrl,
                        $html: $elements,
                        fullRefresh: this.fullRefresh,
                        maskView: this.maskView
                    }));
                }, this);
            }
        },

        destroyChildren: function () {
            var child;
            while ((child = this.children.pop())) {
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
            e.preventDefault();
            e.stopPropagation();
            this.model.toggleSelected();
        },

        showActive: function () {
            this.maskView.highlight(this);
        },

        showSelected: function () {
            this.maskView.select(this);
        },

        showDeselected: function () {
            this.maskView.deselect(this);
        }
    });
});