define([
    'app/models/Component',
    'app/collections/Components'
], function (
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
        }
    });
});