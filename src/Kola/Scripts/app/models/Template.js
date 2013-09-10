define([
    'backbone',
    'app/collections/Components'
], function (Backbone,
    Components) {
    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            var components = new Components();
            components.url = this.url();
            this.set({ components: new Components() });
            //            this.components = new Components();
        },

        addComponent: function (component) {
            this.get("components").add(component);
            component.save();
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