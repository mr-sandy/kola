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

        events: {
            'click .apply': 'apply',
            'click .undo': 'undo'
        },

        render: function () {
            this.$el.html(this.template(this.collection.toJSON()));
        },

        apply: function () {
            this.collection.apply();
        },

        undo: function () {
            var amendment = this.collection.at(this.collection.length - 1);
            amendment.destroy();
        }
    });
});