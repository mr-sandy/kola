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
                this.collection.template.addComponent(args);
            },

            moveComponent: function (args) {
                this.collection.template.moveComponent(args);
            },

            deleteComponent: function (args) {
                this.collection.template.deleteComponent(args);
            },

            _getOrSetComponents: function () {

                var components = this.get('components');

                if (!components) {
                    if (!Component) { Component = require('app/models/Component'); }

                    components = new Components([], { model: Component });
                    components.template = this.collection.template;
                    if (!this.collection.template) { alert("holy moly!")}
                    this.set('components', components);
                }

                return components;
            }

        },
        CompositeComponent));
});