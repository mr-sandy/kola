define([
    'backbone'
], function (Backbone) {

    "use strict";

    return Backbone.Router.extend({

        routes: {
            '_kola2': 'home',
            '_kola2/templates': 'templates',
            '_kola2/templates/create': 'createTemplate',
            '_kola2/templates/*templatePath': 'editTemplate'
        }

    });
});