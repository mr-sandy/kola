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
        initialize: function () {
            var self = this;

            this.get('components').on('addComponent', function (args) {
                self.trigger('addComponent', args);
            });

            this.get('components').on('moveComponent', function (args) {
                self.trigger('moveComponent', args);
            });
        },

        idAttribute: 'componentPath',

        parse: function (resp, xhr) {

            if (!Component) { Component = require('app/models/Component'); }

            if (!this.get('components')) {
                this.set('components', new Components([], { parse: true, model: Component }));
            }

            this.get('components').set(resp.components, { parse: true });

            resp = _.extend(resp,
            {
                'componentPath': _.find(resp.links, function (l) { return l.rel == "componentPath"; }).href
            });

            return _.omit(resp, 'components');
        },

        addComponent: function (args) {
            this.trigger('addComponent', args);
        },

        moveComponent: function (args) {
            this.trigger('moveComponent', args);
        },

        findChild: function (componentPath) {
            if (componentPath.length == 0 || componentPath[0] == '') {
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