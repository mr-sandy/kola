define([
    'backbone',
    'app/models/Component'
], function (Backbone,
    Component) {

    "use strict";

    return Backbone.Collection.extend({

        model: function () {
            if (!Component) {
                Component = require("app/models/Component");
            }

            return Component;
        },

        initialize: function () {
            if (!Component) {
                Component = require("app/models/Component");
            }
        }

    });
});