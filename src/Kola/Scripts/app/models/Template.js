define([
    'backbone'
], function (Backbone) {
    "use strict";

    return Backbone.Model.extend({
        url: function () {
            return "/_kola/templates/" + this.get("id");
            //            return this.combineUrls(config.rootUrl, '/demos');
        }
    });
});