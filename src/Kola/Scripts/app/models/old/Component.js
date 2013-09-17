define([
    'backbone',
    'underscore',
    'app/models/ComponentCollection'
], function (Backbone,
    _,
    ComponentCollection) {

    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            if (!ComponentCollection) {
                ComponentCollection = require("app/models/ComponentCollection");
            }

            this.set({ componentCollection: new ComponentCollection() });
        },

        parse: function (resp, options) {
            this.get("componentCollection").refresh(resp.components);

            resp = _.omit(resp, "components");

            return _.extend(resp, {
                id: _.find(resp.links, function (l) { return l.rel == "self" }).href
            });
        }
    });
});