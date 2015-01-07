define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var PropertyView = require('app/views/PropertyView');
    var Template = require('text!app/templates/PropertiesTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.stateBroker = options.stateBroker;
            this.listenTo(options.stateBroker, 'change', this.render);
        },

        render: function () {
            var model = this.stateBroker.selected ? this.stateBroker.selected.toJSON() : {};
            this.$el.html(this.template(model));

            if (this.stateBroker.selected) {
                var $tbody = this.$('tbody').first();

                _.each(model.parameters, function (parameter) {
                    var propertyView = new PropertyView({
                        model: parameter,
                        el: $tbody
                    });

                    propertyView.render();
                });
            }

            return this;
        }
    });
});