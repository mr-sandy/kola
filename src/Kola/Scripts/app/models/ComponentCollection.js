define([
    'app/models/Component',
    'app/collections/Components'
], function (
    Component,
    Components) {
    "use strict";

    return {

        baseInitialize: function () {
            this.set("components", new Components());
        },

        baseParse: function (resp, xhr) {
            var self = this;

            this.set("url", _.find(resp.links, function (l) { return l.rel == "self"; }).href);
            this.set("id", _.find(resp.links, function (l) { return l.rel == "self"; }).href);
            var components = _.map(resp.components, self.makeComponent);
            this.get("components").add(components);
        },

        makeComponent: function (value, key, list) {

            if (!Component) {
                Component = require("app/models/Component");
            }

            var component = new Component();
            component.parse(value);

            return component;
        }
    }
});