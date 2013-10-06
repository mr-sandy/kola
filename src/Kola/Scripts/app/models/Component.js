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

        parse: function (resp, xhr) {
            return _.omit(resp, 'components');
        },

        addComponent: function (args) {
            this.trigger('addComponent', args);
        },

        moveComponent: function (args) {
            this.trigger('moveComponent', args);
        },

        findChild: function (componentPath) {
            if (componentPath.length == 0) {
                return this;
            }

            var index = componentPath[0];
            var remainder = componentPath.slice(1);
            var components = this.get('components');

            if (index >= components.length) {
                throw "Component index outside bounds";
            }

            var component = components.at(index);

            if (remainder.length == 0) {
                return component;
            }

            return component.findChild(remainder);
        }

    });
});