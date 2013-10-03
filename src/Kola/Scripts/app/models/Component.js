define([
    'backbone',
    'app/models/Component',
    'app/collections/Components'
], function (
    Backbone,
    Component,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    {
        initialize: function (data) {

            if (!Component) {
                Component = require('app/models/Component');
            }

            this.set('componentPath', _.find(data.links, function (l) { return l.rel == "componentPath"; }).href);

            var components = new Components(_.map(data.components, function (value) { return new Component(value); }));
            this.set('components', components);

            var self = this;

            components.on("all", function (eventName, args) {
                self.trigger(eventName, args);
            });
        },

        addComponent: function (args) {
            this.trigger('addComponent', args);
        },

        moveComponent: function (args) {
            this.trigger('moveComponent', args);
        }

    });
});