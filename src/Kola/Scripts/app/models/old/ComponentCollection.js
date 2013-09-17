define([
    'backbone',
    'app/models/Component',
    'app/collections/Components'
], function (Backbone,
    Component,
    Components) {

    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            _.bindAll(this, 'makeComponent');
            this.set("components", new Components());
        },

        addComponent: function (component) {
            alert("Adding Component");
            //this.components.add(component);
        },

        refresh: function (resp) {
            _.map(resp, this.makeComponent)
        },

        makeComponent: function (value, key, list) {

            if (!Component) {
                Component = require("app/models/Component");
            }

            var component = new Component();
            component.parse(value);
            this.get("components").add(component);
        }

    });
});