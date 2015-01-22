define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/WidgetTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'widget',

        initialize: function (options) {
            this.amendmentBroker = options.amendmentBroker;

            this.model.on('sync', this.render, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);
            this.model.on('selected', this.showSelected, this);
            this.model.on('deselected', this.showDeselected, this);
        },

        events: {
            'mouseover': 'handleMouseover',
            'mouseout': 'handleMouseout',
            'click': 'handleClick'
        },

        render: function () {
            var self = this;

            var componentViewFactory = require('app/views/ComponentViewFactory');

            this.$el.html(this.template(this.model.toJSON()));
            this.$el.attr('data-component-path', this.model.get('path'));

            this.model.get('areas').each(function (component) {
                var childView = componentViewFactory.build(component, self.amendmentBroker);
                self.$el.append(childView.render().$el);
            });

            return this;
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

        showActive: function () {
            this.$el.addClass('active');
        },

        showInactive: function () {
            this.$el.removeClass('active');
        },

        showSelected: function () {
            this.$el.addClass('selected');
        },

        showDeselected: function () {
            this.$el.removeClass('selected');
        }
    });
});