var Backbone = require('backbone');

module.exports = Backbone.Router.extend({

    routes: {
        '_kola': 'home',
        '_kola/templates': 'templates',
        '_kola/templates/create': 'createTemplate',
        '_kola/templates/*templatePath': 'editTemplate'
    }
});