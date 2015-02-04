define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Area = require('app/models/Area');

    return Backbone.Collection.extend({
        model: Area
    });
});
