define([
    'backbone',
    'app/collections/Components'
], function (Backbone,
    Components) {
    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            this.components = new Components();
        },

        addComponent: function (component) {
            this.components.add(component);
        },

        url: function () {
            return "/_kola/templates/" + this.get("id");
            //            return this.combineUrls(config.rootUrl, '/demos');
        },

        parse: function (resp, xhr) {
            return resp;
        }
    });
});