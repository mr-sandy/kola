define([
    'backbone',
    'handlebars',
    'text!app/templates/HomeTemplate.html'
], function (Backbone,
    Handlebars,
    HomeTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(HomeTemplate),

        render: function () {
            this.$el.html(this.template());
        }
    });
});