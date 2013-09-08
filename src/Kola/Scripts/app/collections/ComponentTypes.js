define([
    'backbone',
    'app/models/ComponentType'
], function (Backbone,
    ComponentType) {

    "use strict";

    return Backbone.Collection.extend({

        model: ComponentType,

        url: "/_kola/component-types"
    });
});