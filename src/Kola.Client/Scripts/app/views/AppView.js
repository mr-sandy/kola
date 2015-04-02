define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');

    var LoadingView = require('app/views/LoadingView');

    var homeHandler = require('app/handlers/HomeHandler');
    var editTemplateHandler = require('app/handlers/EditTemplateHandler');

    return Backbone.View.extend({

        initialize: function (options) {
            this.options = options;

            var handlerMappings = {
                'route:home': homeHandler,
                'route:editTemplate': editTemplateHandler
            };

            _.each(handlerMappings, function (handler, route) {
                options.router.on(route, function () {
                    this.handleRoute(handler, arguments);
                }, this);
            }, this);
        },

        handleRoute: function (handler, args) {
            var self = this;

            this.closeCurrentView()

            this.showView(new LoadingView());

            var options = {
                router: self.options.router
            };

            handler.execute.apply(null, [options].concat(_.flatten(args))).then(function (view) {
                self.closeCurrentView();
                self.showView(view);
            });
        },

        closeCurrentView: function () {
            if (this.currentView) {
                this.currentView.setElement('');
                return this.currentView.remove();
            }
        },

        showView: function (view) {
            if (this.currentView) {
                this.currentView.undelegateEvents();
            }
            this.currentView = view;
            this.currentView.setElement('.application').render();
        }
    });
});