var Backbone = require('backbone');
var _ = require('underscore');
var componentFactory = require('app/models/ComponentFactory');

module.exports = Backbone.Collection.extend({

    parse: function (response) {

        return _.map(response, componentFactory.build);
    }
});
