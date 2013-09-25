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
            }
        }).extend(ComponentCollection);
});