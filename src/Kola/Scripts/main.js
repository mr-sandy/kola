require.config({
    paths: {
        jquery: '/Scripts/jquery-2.1.3.min',
        jqueryui: '/Scripts/jquery-ui-1.11.3.min',
        underscore: '/Scripts/underscore.min',
        backbone: '/Scripts/backbone.min',
        'backbone-hypermedia': '/Scripts/backbone-hypermedia-amd',
        handlebars: '/Scripts/handlebars.min',
        text: '/Scripts/text',
        tabbed: 'app/controls/tabbed'
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