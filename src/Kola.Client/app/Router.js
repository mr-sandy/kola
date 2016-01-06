var Backbone = require('backbone');

module.exports = Backbone.Router.extend({

    routes: {
        '_kola': 'home',
        '_kola/templates': 'viewTemplates',
        '_kola/template/create': 'createTemplate',
        '_kola/template?templatePath=*templatePath': 'editTemplate'
    }
});