define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var domHelper = require('app/views/DomHelper');

    return Backbone.View.extend({

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);

            this.initialiseMouseEventHandlers();
        },

        render: function () {
            var self = this;
            var WysiwygComponentView = require('app/views/WysiwygComponentView');

            var children = this.model.get('components') || this.model.get('areas');

            if (children) {

                children.each(function (component) {
                    var $elements = domHelper.findElements(self.$el, component.get('path'));

                    var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                    wysiwygComponentView.render();
                });
            }
        },

        initialiseMouseEventHandlers: function () {
            var self = this;
            var ownedElements = $(domHelper.findDirectlyOwned(this.$el));

            ownedElements.on('mouseover', function (e) {
                e.stopPropagation();
                self.model.trigger('active');
            });

            ownedElements.on('mouseout', function (e) {
                e.stopPropagation();
                self.model.trigger('inactive');
            });
        },

        refresh: function () {
            var self = this;
            var url = '/_kola/preview/nelly?componentPath=' + this.model.get('path');

            $.ajax({
                url: url,
                dataType: 'html'
            }).done(function (data) {

                self.setElement(domHelper.replace(self.$el, data));

                self.initialiseMouseEventHandlers();

                self.render();
            })
        },

        showActive: function () {
            this.$el.css({ "background-color": "#ccc" });
        },

        showInactive: function () {
            this.$el.css({ "background-color": "transparent" });
        }
    });
});