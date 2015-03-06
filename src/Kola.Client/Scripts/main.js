require.config({
    paths: {
        jquery: 'jquery-2.1.3.min',
        jqueryui: 'jquery-ui-1.11.3.min',
        underscore: 'underscore.min',
        backbone: 'backbone.min',
        'backbone-hypermedia': 'backbone-hypermedia-amd',
        handlebars: 'handlebars.min',
        text: 'text',
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