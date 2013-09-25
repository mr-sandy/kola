define([
    'backbone',
    'app/models/ComponentCollection'
], function (
    Backbone,
    ComponentCollection) {
    "use strict";

    return Backbone.Model.extend(
        {
            baseParse: function (resp, xhr) {
                return resp;
            },

            url: function () { return "jam" +  this.get("url"); }

            //            url: function () {
            //                return "/_kola/templates/" + this.get("id");
            //            }
        }).extend(ComponentCollection);
});