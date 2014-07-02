define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var componentFactory = require('app/models/ComponentFactory');

    return Backbone.Collection.extend({

        parse: function (response) {

            return _.map(response, componentFactory.build);
        }
    });
});
