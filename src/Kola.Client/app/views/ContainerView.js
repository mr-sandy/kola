var Backbone = require('backbone');
var _ = require('underscore');
var template = require('app/templates/ContainerTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    tagName: 'li',

    className: 'container',

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
        'click i.collapse': 'toggle',
        'click i.comment': 'toggleComment',
        'click textarea.comment': function (e) { e.stopPropagation(); },
        'focusout textarea.comment': 'submitComment'
    },

    render: function () {
        var self = this;

        var componentViewFactory = require('app/views/ComponentViewFactory');

        this.$el.html(this.template(_.extend(this.model.toJSON(), { collapsed: this.collapsed })));
        this.$el.attr('data-component-path', this.model.get('path'));

        var $list = this.$('ol').first();

        this.model.get('components').each(function (component) {
            var childView = componentViewFactory.build(component, self.amendmentBroker);
            $list.append(childView.render().$el);
        });

        $list.sortable({
            opacity: 0.75,
            placeholder: 'new',
            tolerance: 'pointer',
            connectWith: 'ol',
            stop: this.amendmentBroker.handleStop
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

    toggle: function (e) {
        e.stopPropagation();
        this.collapsed = !this.collapsed || false;
        this.$el.children('ol').slideToggle(100);
        this.$el.toggleClass('collapsed');
    },

    toggleComment: function (e) {
        e.stopPropagation();
        this.$el.children('span.comment').toggle();
        this.$el.children('textarea.comment').toggle().focus().select();
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