var Backbone = require('backbone');

module.exports = Backbone.Router.extend({

    routes: {
        '_kola': 'home',
        '_kola/template': 'templates',
        '_kola/template/create': 'createTemplate',
        '_kola/template/edit/*templatePath': 'editTemplate'
    }
});