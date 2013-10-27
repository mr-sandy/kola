define([
    'backbone',
    'underscore',
    'app/models/CompositeComponent',
    'app/collections/Components'
], function (
    Backbone,
    _,
    CompositeComponent,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            componentPath: '',

            parse: function (resp, options) {

                this.components = new Components(resp.components, { parse: true });
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