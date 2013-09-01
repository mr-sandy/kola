define([
    'backbone',
    'handlebars',
    'text!app/templates/TemplatesTemplate.html'
], function (Backbone,
    Handlebars,
    TemplatesTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(TemplatesTemplate),

        render: function () {
            this.$el.html(this.template());
        },

        events: {
            'click a#createTemplate': 'navigate'
        },

    });
});