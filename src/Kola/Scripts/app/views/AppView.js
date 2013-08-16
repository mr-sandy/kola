define([
    'backbone',
    'handlebars',
    'jquery',
    'app/views/LoadingView',
    'app/views/HomeView',
    'app/views/NavigationView',
    'app/views/PagesView',
    'bootstrap'
], function (Backbone,
    Handlebars,
    $,
    LoadingView,
    HomeView,
    NavigationView,
    PagesView) {

    "use strict";

    return Backbone.View.extend({

        initialize: function () {
            //            $('.loading').remove(); // remove server delivered loading spinner

            this.navigationView = new NavigationView({
                router: this.options.router
            });

            this.listenTo(this.options.router, 'route:home', this.home);
            this.listenTo(this.options.router, 'route:pages', this.pages);
        },

        render: function () {
            this.navigationView.setElement('#navigation').render();
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

            if (this.closeCurrentView()) {
                var homeView = new HomeView({ router: this.options.router });
                this.showView(homeView);
            }

            //            this.showView(homeView);
//            this.showView(new LoadingView());
            //            if (this.closeCurrentView()) {
            //                //                this.showView(new LoadingView());

            //                //                this.collection.fetch().then(function () {
            //                self.closeCurrentView();
            //                self.showView(homeView);
            //                //                });
            //            }
        },

        pages: function () {
            var self = this;

            if (this.closeCurrentView()) {
                var pagesView = new PagesView({ router: this.options.router });
                this.showView(pagesView);
            }
        }
    });
});