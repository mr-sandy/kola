define([
    'backbone',
    'app/models/Component'
], function (Backbone,
    Component) {

    "use strict";

    return Backbone.Collection.extend({
        model: Component,

        url: "/_kola/components"
    });
});