var Backbone = require('backbone');
var ComponentType = require('app/models/ComponentType');

module.exports = Backbone.Collection.extend({

    model: ComponentType,

    url: '/_kola/component-types'
});
