define([
    'backbone',
    'underscore',
    'app/models/Component',
    'app/models/CompositeComponent',
    'app/collections/Components'
], function (
    Backbone,
    _,
    Component,
    CompositeComponent,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            componentPath: '',

            initialize: function () {
                var self = this;

                if (!Component) { Component = require('app/models/Component'); }

                var components = new Components([], { model: Component });
                components.template = this;
                this.set('components', components);
            },

            parse: function (resp, xhr) {

                this.get('components').set(resp.components, { parse: true });
                this.amendmentsUrl = _.find(resp.links, function (l) { return l.rel == "amendments"; }).href;
                return _.omit(resp, 'components');
            },

            refresh: function (componentUrl) {
                var componentPath = componentUrl
                    ? _.without(componentUrl.split('/'), '')
                    : [];
                var component = this._findChild(componentPath);
                component.fetch().then(function () {
                    component.trigger('change');
                });
            }
        },
        CompositeComponent));
});