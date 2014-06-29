define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    require('jqueryui');
    var Template = require('text!app2/templates/ContainerTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'container',

        initialize: function () {
            this.model.on('sync', this.render, this);
        },

        render: function () {
            var componentViewFactory = require('app2/views/ComponentViewFactory');

            this.$el.html(this.template());
            this.$el.attr('data-component-path', this.model.get('path'));

            var $list = this.$('ul').first();

            this.model.get('components').each(function (component) {
                var childView = componentViewFactory.build(component);
                $list.append(childView.render().$el);
            });

            $list.find('ul').sortable({
                opacity: 0.75,
                placeholder: 'new',
                tolerance: 'pointer',
                connectWith: 'ul',
                stop: this.handleStop
            });

            return this;
        }
    });
});