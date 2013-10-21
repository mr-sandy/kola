define([
    'backbone',
    'app/Config',
    'app/models/Component',
    'app/models/CompositeComponent',
    'app/collections/Components'
], function (
    Backbone,
    Config,
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

                var componentPath = _.find(resp.links, function (l) { return l.rel == "self"; }).href;
                this.url = this.combineUrls(Config.kolaRoot, componentPath);

                resp = _.extend(resp,
                            {
                                'componentPath': _.find(resp.links, function (l) { return l.rel == "componentPath"; }).href,
                                'path': this.url
                            });

                return _.omit(resp, 'components', 'amendments');
            },

            _getOrSetComponents: function () {

                var components = this.get('components');

                if (!components) {
                    if (!Component) { Component = require('app/models/Component'); }

                    components = new Components([], { model: Component });
                    components.template = this.collection.template;
                    if (!this.collection.template) { alert("holy moly!") }
                    this.set('components', components);
                }

                return components;
            }

        },
        CompositeComponent));
});