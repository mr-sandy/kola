define([
    'backbone',
    'handlebars',
    'jquery',
    'app/views/HeaderView',
    'bootstrap'
], function (Backbone,
    Handlebars,
    $,
    HeaderView) {
    "use strict";

    return Backbone.View.extend({

        initialize: function () {
            //            $('.loading').remove(); // remove server delivered loading spinner

            this.headerView = new HeaderView({
                router: this.options.router
            });

            this.listenTo(this.options.router, 'route:home', this.home);
            this.listenTo(this.options.router, 'route:create', this.create);
        },

        render: function () {
            this.headerView.setElement('#header').render();
        },

        closeCurrentView: function () {
            if (this.currentView) {
                this.currentView.setElement('');
                return this.currentView.close();
            }
            return true;
        },

        showView: function (view) {
            this.currentView = view;
            this.currentView.setElement('#content').render();
        },

        home: function () {
            var self = this;

            var homeView = new HomeView({
                collection: this.collection,
                router: this.options.router
            });

            if (this.closeCurrentView()) {
                this.showView(new LoadingView());

                this.collection.fetch().then(function () {
                    self.closeCurrentView();
                    self.showView(homeView);
                });
            }
        },

        create: function () {
            alert("Hello Mr");
        }
    });
});