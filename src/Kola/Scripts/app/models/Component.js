define([
    'app/Config',
    'app/models/Component',
    'app/collections/Components'
], function (
    Config,
    Component,
    Components) {
    'use strict';

    return Backbone.Model.extend(
    {
        initialize: function (data) {

            if (!Component) {
                Component = require('app/models/Component');
            }

            var components = new Components(_.map(data.components, function (value) { return new Component(value); }));

            this.componentPath = _.find(data.links, function (l) { return l.rel == "componentPath"; }).href;


            this.set('components', components);
        }
    });
});