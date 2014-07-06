define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/ContainerTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: function () { return this.model.get('type'); },

        initialize: function (options) {
            this.options = options;

            this.model.on('sync', this.render, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);
        },

        events: {
            "mouseover": "activate",
            "mouseout": "deactivate"
        },

        render: function () {
            var self = this;

            this.$el.html(this.template(this.model.toJSON()));
            this.$el.attr('data-component-path', this.model.get('path'));

            var $list = this.$('ul').first();

            if (this.options.childAccessor) {
                var componentViewFactory = require('app/views/ComponentViewFactory');

                this.model.get(this.options.childAccessor).each(function (component) {
                    var childView = componentViewFactory.build(component, self.options.amendmentBroker);
                    $list.append(childView.render().$el);
                });
            }

            if (this.options.sortable) {
                $list.sortable({
                    opacity: 0.75,
                    placeholder: 'new',
                    tolerance: 'pointer',
                    connectWith: 'ul',
                    stop: this.options.amendmentBroker.handleStop
                });
            }
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

        showActive: function () {
            this.$el.addClass('active');
        },

        showInactive: function () {
            this.$el.removeClass('active');
        }
    });
});