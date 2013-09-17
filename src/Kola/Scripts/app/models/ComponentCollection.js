﻿define([
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

        baseParse: function (resp, xhr) {
            return resp;
        },

        initialize: function () {
            _.bindAll(this, 'makeComponent');
            this.set("components", new Components());
            this.baseInitialize();
        },

        parse: function (resp, xhr) {
            _.map(resp.components, this.makeComponent);

            return this.baseParse(resp, xhr);
        },

        makeComponent: function (value, key, list) {

            if (!Component) {
                Component = require("app/models/Component");
            }

            var component = new Component();
            component.parse(value);
            this.get("components").add(component);
        }
    }
});