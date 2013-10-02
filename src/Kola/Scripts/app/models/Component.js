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

            var components = (data && data.components)
                ? new Components(_.map(data.components, function (value, index) {
                    return new Component(_.extend(value, { id: index }));
                }))
                : new Components();

            if (data && data.links) {
                this.url = this.combineUrls(Config.templatesRoot, _.find(data.links, function (l) { return l.rel == "self"; }).href);
                components.url = this.url;
            }

            this.set('components', components);
        }
    });
});