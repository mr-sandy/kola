﻿define([
    'backbone',
    'handlebars',
    'text!app/templates/NavigationTemplate.html'
], function (Backbone,
    Handlebars,
    NavigationTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(NavigationTemplate),

        render: function () {
            this.$el.html(this.template());
        },

        events: {
            'click a': 'navigate'
        }
    });
});