define([
    'backbone',
    'app2/views/AppView',
    'app2/Router',
    'app2/Extensions'
], function (
    Backbone,
    AppView,
    Router) 
{
    "use strict";
    return {

        init: function () {
            var appView = new AppView({
                router: new Router()
            });

            appView.render();

            Backbone.history.start({ pushState: true });
        }
    };
});