define([
    'underscore',
    'app/models/Component',
    'app/collections/Components'
], function (
    _,
    Component,
    Components) {
    "use strict";

    return {

        baseInitialize: function () {
        },

        initialize: function () {
            //            _.bindAll(this, 'makeComponent');
            this.set("components", new Components());
            this.baseInitialize();
        },

        parse: function (resp, xhr) {
            var self = this;
            var components = _.map(resp.components, self.makeComponent);

            this.get("components").add(components);

            return this.baseParse(resp, xhr);
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