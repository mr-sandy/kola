define([
    'backbone',
    'handlebars',
    'jquery',
    'app/Config',
    'app/models/Template',
    'app/collections/Amendments',
    'app/collections/ComponentTypes',
    'app/views/LoadingView',
    'app/views/HomeView',
    'app/views/NavigationView',
    'app/views/TemplatesView',
    'app/views/CreateTemplateView',
    'app/views/EditTemplateView',
    'bootstrap',
    'jqueryui'
], function (Backbone,
    Handlebars,
    $,
    Config,
    Template,
    Amendments,
    ComponentTypes,
    LoadingView,
    HomeView,
    NavigationView,
    TemplatesView,
    CreateTemplateView,
    EditTemplateView
) {

    'use strict';

    return Backbone.View.extend({

        initialize: function (options) {
            this.options = options;
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
            if (this.closeCurrentView()) {
                var homeView = new HomeView({ router: this.options.router });
                this.showView(homeView);
            }
        },

        templates: function () {
            if (this.closeCurrentView()) {
                var templatesView = new TemplatesView({ router: this.options.router });
                this.showView(templatesView);
            }
        },

        createTemplate: function () {
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

            var template = new Template();
            template.url = this.combineUrls(Config.kolaRoot, templatePath);

            var amendments = new Amendments();
            amendments.url = this.combineUrls(template.url, '_amendments');

            var componentTypes = new ComponentTypes();

            var editTemplateView = new EditTemplateView({
                model: template,
                router: this.options.router,
                amendments: amendments,
                componentTypes: componentTypes
            });

            if (this.closeCurrentView()) {
                $.when(template.fetch(), amendments.fetch(), componentTypes.fetch())
                    .done(function () {
                        self.showView(editTemplateView);

                        template.listenTo(amendments, 'sync', function (amendment) {
                            template.refresh(amendment.get('subject'));
                        });
                    })
                    .fail(function () {
                        alert('failure!');
                    });
            }
        }
    });
});
