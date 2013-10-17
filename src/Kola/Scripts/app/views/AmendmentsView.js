define([
    'backbone',
    'handlebars',
    'app/collections/ComponentTypes',
    'text!app/templates/AmendmentsTemplate.html'
], function (Backbone,
    Handlebars,
    ComponentTypes,
    AmendmentsTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(AmendmentsTemplate),

        initialize: function () {
            this.collection.on('sync', this.render, this);
            this.collection.on('change', this.render, this);
        },

        render: function () {
            this.$el.html(this.template(this.collection.toJSON()));
        }
    });
});