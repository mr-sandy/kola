require.config({
    paths: {
        jquery: 'jquery-2.1.1.min',
        jqueryui: 'jquery-ui-1.10.3.custom.min',
        underscore: 'underscore.min',
        backbone: 'backbone',
//        backbone: 'backbone.min',
        handlebars: 'handlebars.min'
    },
    shim: {
        underscore: {
            exports: '_'
        },
        backbone: {
            deps: ['underscore', 'jquery'],
            exports: 'Backbone'
        },
        handlebars: {
            exports: 'Handlebars'
        }
    },
    waitSeconds: 15 // IE8 was timing out without this
});

require(['app/App'], function (App) {
    "use strict";
    App.init();
});