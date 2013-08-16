define([
    'backbone'
], function (Backbone) {

    "use strict";

    return Backbone.Router.extend({

        routes: {
            '_kola': 'home',
            '_kola/pages': 'pages'
        }

    });
});