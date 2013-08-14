define([
    'backbone',
    'handlebars',
    'text!app/templates/HeaderTemplate.html'
], function (Backbone, Handlebars, HeaderTemplate) {
    "use strict";
    return Backbone.View.extend({

        template: Handlebars.compile(HeaderTemplate),

        render: function () {
            this.$el.html(this.template);

            return this;
        }
    });
});