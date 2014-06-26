define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Area = require('app2/models/Area');

    return Backbone.Collection.extend({
        model: Area
    });
});
