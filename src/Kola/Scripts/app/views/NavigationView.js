define([
    'backbone',
    'handlebars',
    'text!app/templates/NavigationTemplate.html'
], function (Backbone,
    Handlebars,
    NavigationTemplate) {

    "use strict";

    return Backbone.View.extend({

        initialize: function () {
            this.listenTo(this.options.router, 'route:home', this.home);
            this.listenTo(this.options.router, 'route:pages', this.pages);
        },

        template: Handlebars.compile(NavigationTemplate),

        render: function () {
            this.$el.html(this.template());
        },

        events: {
            'click a': 'navigate'
        },

        navigate: function (e) {
            e.preventDefault();
            this.options.router.navigate($(e.target).attr('href'), { trigger: true });
        },

        home: function (e) {
            alert("Home!");
        },

        pages: function () {
            alert("Pages!");
        }
    });
});