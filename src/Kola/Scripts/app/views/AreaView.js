define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/AreaTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'div',

        className: 'area',

        initialize: function (options) {
            this.amendmentBroker = options.amendmentBroker;
            this.model.on('sync', this.render, this);
        },

        render: function () {
            var self = this;

            var componentViewFactory = require('app/views/ComponentViewFactory');

            this.$el.html(this.template());
            this.$el.attr('data-component-path', this.model.get('path'));

            var $list = this.$('ul').first();

            this.model.get('components').each(function (component) {
                var childView = componentViewFactory.build(component, self.amendmentBroker);
                $list.append(childView.render().$el);
            });

            $list.sortable({
                opacity: 0.75,
                placeholder: 'new',
                tolerance: 'pointer',
                connectWith: 'ul',
                stop: this.amendmentBroker.handleStop
            });

            return this;
        }
    });
});