define([
    'backbone',
    'underscore'
], function (Backbone, _) {

    "use strict";

    return Backbone.Model.extend({
        parse: function (resp, options) {

            this.set("id", _.find(resp.links, function (l) { return l.rel == "self" }).href);

            return resp;
        }
    });
});