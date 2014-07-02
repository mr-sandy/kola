define([
    'backbone',
    'handlebars',
    'app/views/AmendmentView',
    'text!app/templates/AmendmentsTemplate.html'
], function (Backbone,
    Handlebars,
    AmendmentView,
    AmendmentsTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(AmendmentsTemplate),

        initialize: function () {
            this.listenTo(this.collection, 'sync', this.render);
        },

        events: {
            'click .apply': 'apply'
        },

        render: function () {
            var self = this;

            this.$el.html(this.template());
            var $list = this.$el.find('ul');

            this.collection.each(function (amendment) {
                self.assign(new AmendmentView({ model: amendment }), $list);
            });

            return this;
        },

        apply: function () {
            this.collection.apply();
        }
    });
});