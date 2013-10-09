define([
    'backbone',
    'app/models/Component',
    'app/models/CompositeComponent',
    'app/collections/Components'
], function (
    Backbone,
    Component,
    CompositeComponent,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            idAttribute: 'componentPath',

            initialize: function () {
                var self = this;

                this.get('components').on('addComponent', function (args) {
                    self.trigger('addComponent', args);
                });

                this.get('components').on('moveComponent', function (args) {
                    self.trigger('moveComponent', args);
                });
            },

            parse: function (resp, xhr) {

                var components = this._getOrSetComponents();

                components.set(resp.components, { parse: true });

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

            _getOrSetComponents: function () {

                var components = this.get('components');

                if (!components) {
                    if (!Component) { Component = require('app/models/Component'); }

                    components = new Components([], { parse: true, model: Component });

                    this.set('components', components);
                }

                return components;
            }

        },
        CompositeComponent));
});