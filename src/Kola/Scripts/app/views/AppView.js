define([
    'backbone',
    'handlebars',
    'jquery',
    'app/views/LoadingView',
    'app/views/HomeView',
    'app/views/NavigationView',
    'app/views/TemplatesView',
    'app/views/CreateTemplateView',
    'app/views/EditTemplateView',
    'app/models/Template',
    'bootstrap',
    'jqueryui'
], function (Backbone,
    Handlebars,
    $,
    LoadingView,
    HomeView,
    NavigationView,
    TemplatesView,
    CreateTemplateView,
    EditTemplateView,
    Template) {

    "use strict";

    return Backbone.View.extend({

        initialize: function () {
            //            $('.loading').remove(); // remove server delivered loading spinner

            this.navigationView = new NavigationView({
                router: this.options.router
            });

            this.listenTo(this.options.router, 'route:home', this.home);
            this.listenTo(this.options.router, 'route:templates', this.templates);
            this.listenTo(this.options.router, 'route:createTemplate', this.createTemplate);
            this.listenTo(this.options.router, 'route:editTemplate', this.editTemplate);
        },

        render: function () {
            this.assign(this.navigationView, '#navigation');
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

        templates: function () {
            var self = this;

            if (this.closeCurrentView()) {
                var templatesView = new TemplatesView({ router: this.options.router });
                this.showView(templatesView);
            }
        },

        createTemplate: function () {
            var self = this;

            if (this.closeCurrentView()) {
                var createTemplateView = new CreateTemplateView({
                    model: new Template(),
                    router: this.options.router
                });
                this.showView(createTemplateView);
            }
        },

        editTemplate: function (templatePath) {
            var self = this;

            var template = new Template({ id: templatePath });

            if (this.closeCurrentView()) {
                var editTemplateView = new EditTemplateView({
                    model: template,
                    router: this.options.router
                });

                template.fetch()
                    .then(function () {
                        self.showView(editTemplateView);
                    })
                    .fail(function () {
                        alert("failure!");
                    });
            }
        }
    });
});