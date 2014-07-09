define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var domHelper = require('app/views/DomHelper');

    return Backbone.View.extend({

        events: {
            'mouseover': 'activate',
            'mouseout': 'deactivate'
        },

        initialize: function (options) {
            this.listenTo(this.model, 'sync', this.handleSync);
            this.listenTo(this.model, 'active', this.showActive);
            this.listenTo(this.model, 'inactive', this.showInactive);

            this.children = [];

            this.setElement(domHelper.findDirectlyOwned(options.$html));
            this.buildChildren(options.$html);
        },

        handleSync: function () {
            $.ajax({
                url: '/_kola/preview/nelly?componentPath=' + this.model.get('path'),
                dataType: 'html',
                context: this
            }).done(this.refresh);
        },

        refresh: function (html) {

            var $html = $(html);
            domHelper.replace(this.$el[0], this.$el[this.$el.length - 1], $html);

            this.setElement(domHelper.findDirectlyOwned($html));
            this.buildChildren($html)
        },

        buildChildren: function ($html) {

            this.destroyChildren();

            var childComponents = this.model.get('components') || this.model.get('areas');

            if (childComponents) {

                var WysiwygComponentView = require('app/views/WysiwygComponentView');

                childComponents.each(function (component) {
                    var $elements = domHelper.findElements($html, component.get('path'));
                    this.children.push(new WysiwygComponentView({ model: component, $html: $elements }));
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
            this.model.trigger('active');
        },

        deactivate: function (e) {
            e.stopPropagation();
            this.model.trigger('inactive');
        },

        showActive: function () {
            this.$el.css({ "background-color": "#ccc" });
        },

        showInactive: function () {
            this.$el.css({ "background-color": "transparent" });
        }
    });
});