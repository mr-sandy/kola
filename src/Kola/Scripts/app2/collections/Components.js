define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Component = require('app2/models/Component');

    return Backbone.Collection.extend({
        model: Component
    });
});
