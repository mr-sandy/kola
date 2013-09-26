define([
    'app/models/Component',
    'app/collections/Components'
], function (
    Component,
    Components) {
    "use strict";

    return Backbone.Model.extend(
    {
        initialize: function () {
            this.set("components", new Components());
        },

        parse: function (resp, xhr) {
            var components = _.map(resp.components, function (value) { return new Component(value); });
            this.get("components").reset(components);

            return _.omit(resp, "components");
        },

        url: function () {
            return "_kola/templates/" + this.id;
        }
    });
});