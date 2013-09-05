define([
    'backbone',
    'app/models/ComponentDefinition'
], function (Backbone,
    Component) {

    "use strict";

    return Backbone.Collection.extend({

        model: Component,

        url: "/_kola/component-types"
    });
});