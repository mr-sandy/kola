define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/AtomTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: function () { return 'atom' },

        initialize: function (options) {
            this.stateBroker = options.stateBroker;

            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);
            this.model.on('selected', this.showSelected, this);
            this.model.on('deselected', this.showDeselected, this);
        },

        events: {
            "mouseover": "activate",
            "mouseout": "deactivate",
            "click": "select"
        },

        render: function () {
            this.$el.html(this.template(this.model.toJSON()));
            this.$el.attr('data-component-path', this.model.get('path'));

            return this;
        },

        activate: function (e) {
            this.model.trigger('active');
            e.stopPropagation();
        },

        deactivate: function (e) {
            this.model.trigger('inactive');
            e.stopPropagation();
        },

        select: function (e) {
            this.stateBroker.select(this.model);
            e.stopPropagation();
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