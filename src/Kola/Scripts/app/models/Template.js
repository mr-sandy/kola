define([
    'backbone',
    'app/collections/Components'
], function (Backbone,
    Components) {
    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            this.set({ components: new Components() });
            this.on("componentAdded", function () { alert("oh my!"); });
        },

        addComponent: function (component) {
            var self = this;
            this.get("components").add(component);
            component.save()
                .then(function () {
                    self.trigger("componentAdded", "an event");
                });
        },

        url: function () {
            return "/_kola/templates/" + this.get("id");
            //            return this.combineUrls(config.rootUrl, '/demos');
        },

        componentsUrl: function () {
            return this.url() + "/_components";
        },


        parse: function (resp, xhr) {
            return resp;
        }
    });
});