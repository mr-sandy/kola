define([
    'backbone',
    'handlebars',
    'text!app/templates/PagesTemplate.html'
], function (Backbone,
    Handlebars,
    PagesTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(PagesTemplate),

        render: function () {
            this.$el.html(this.template());
        }
    });
});