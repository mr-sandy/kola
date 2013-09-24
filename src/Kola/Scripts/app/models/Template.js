define([
    'backbone',
    'underscore',
    'app/models/ComponentCollection'
], function (Backbone,
    _,
    ComponentCollection) {

    "use strict";

    return Backbone.Model.extend(
        _.extend(        
        {
            baseParse: function (resp, xhr) {
                return resp;
            },
            
            url: function () {
                return "/_kola/templates/" + this.get("id");
            }
        },
        ComponentCollection
        ));
});