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
            this.listenTo(options.stateBroker, 'change', this.handleSelectionChange);
        },

        handleSelectionChange: function () {
            this.model = this.stateBroker.selected;
            this.render();
        },

        render: function () {

            var context = this.model ? this.model.toJSON() : {};

            this.$el.html(this.template(context));

            if (this.model) {
                var $tbody = this.$('tbody').first();

                _.each(this.model.get('parameters'), function (parameter) {
                    var $row = $tbody.append('<tr></tr>').find('tr').last();
                    var propertyView = new PropertyView({
                        model: parameter,
                        el: $row
                    });

                    propertyView.render();
                });
            }

            return this;
        }
    });
});