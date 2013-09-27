define([
    'backbone',
    'app/models/Component',
    'app/collections/Components'
], function (
    Backbone,
    Component,
    Components) {
    "use strict";

    return Backbone.Model.extend(
    {
        initialize: function (resp) {
            if (!Component) {
                Component = require("app/models/Component");
            }

            var components = (resp && resp.components) 
                ? new Components(_.map(resp.components, function (value) { return new Component(value); }))
                : new Components();

            this.set("components", components);

            //            this.set("url", _.find(resp.links, function (l) { return l.rel == "self"; }).href);
            //            this.set("id", _.find(resp.links, function (l) { return l.rel == "self"; }).href);
        }
    });
});