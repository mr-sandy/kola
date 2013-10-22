define([
    'backbone',
    'handlebars',
    'text!app/templates/AmendmentTemplate.html'
], function (Backbone,
    Handlebars,
    AmendmentTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(AmendmentTemplate),

        events: {
            'click .undo': 'undo'
        },

        render: function () {
            this.$el.prepend(this.template(this.model.toJSON()));
            return this;
        },

        undo: function () {
            this.model.destroy();
        }
    });
});