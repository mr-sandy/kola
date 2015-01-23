define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/AtomTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'atom',

        initialize: function (options) {
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
            this.$el.html(this.template(this.model.toJSON()));
            this.$el.attr('data-component-path', this.model.get('path'));

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
            this.ensureVisible(this.$el);
        },

        showDeselected: function () {
            this.$el.removeClass('selected');
        },

        ensureVisible: function ($el) {
            var offsetTop = $el.position().top;
            var parent = $el.offsetParent();
            var scrollTop = parent.scrollTop() + offsetTop - 50;

            parent.animate({ scrollTop: scrollTop }, 500);
        }
    });
});