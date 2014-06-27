define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app2/templates/AreaTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'div',

        className: 'area',

        render: function () {
            var componentViewFactory = require('app2/views/ComponentViewFactory');

            this.$el.html(this.template());
            this.$el.attr('data-component-path', this.model.get('path'));

            var $list = this.$('ul').first();

            this.model.get('components').each(function (component) {
                var childView = componentViewFactory.build(component);
                $list.append(childView.render().$el);
            });

            return this;
        }
    });
});