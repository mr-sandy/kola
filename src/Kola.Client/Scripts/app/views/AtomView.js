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
            'click': 'handleClick',
            'click i.comment': 'editComment',
            'click span.comment': 'editComment',
            'focusout textarea.comment': 'submitComment'
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

        editComment: function (e) {
            e.stopPropagation();
            this.$el.children('span.comment').hide();
            this.$el.children('textarea.comment').show().focus().select();
        },

        submitComment: function (e) {
            e.stopPropagation();
            var comment = this.$el.children('textarea.comment').val();

            if (comment !== this.model.get('comment')) {
                this.amendmentBroker.setComment(this.$el.attr('data-component-path'), comment);
            } else {
                this.$el.children('span.comment').show();
                this.$el.children('textarea.comment').hide();
            }
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
            var scrollTop = $el.position().top;
            $el.closest('div.content').animate({ scrollTop: scrollTop }, 500);
        }
    });
});