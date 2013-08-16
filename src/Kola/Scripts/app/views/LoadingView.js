define([
    'backbone',
    'handlebars',
    'text!app/templates/LoadingTemplate.html'
], function (Backbone,
    Handlebars,
    LoadingTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(LoadingTemplate),

        render: function () {
            this.$el.html(this.template());
        }
    });
});