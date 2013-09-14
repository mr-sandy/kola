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
            this.set({ components: new ComponentCollection() });
        },

        parse: function (resp, options) {
            this.get("components").refresh(resp.components);

            resp = _.omit(resp, "components");

            return _.extend(resp, {
                id: _.find(resp.links, function (l) { return l.rel == "self" }).href
            });
        }
    });
});