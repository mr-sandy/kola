define([
    'backbone',
    'underscore',
    'app/collections/Components'
], function (Backbone,
    _,
    Components) {

    "use strict";

    return Backbone.Model.extend({

        initialize: function () {
            this.components = new Components();
        },

        addComponent: function (component) {
            alert("Adding Component");
            //this.components.add(component);
        },

        parse: function (resp, options) {

            var id = _.find(resp.links, function (l) { return l.rel == "self" }).href;

            return _.extend(resp, { id: id });
        }
    });
});