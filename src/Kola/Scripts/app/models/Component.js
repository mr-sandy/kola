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
            var self = this;

            if (!Component) {
                Component = require('app/models/Component');
            }

            var components = (data && data.components)
                ? new Components(_.map(data.components, function (value, index) {
                    return new Component(_.extend(value, { id: index }));
                }))
                : new Components();

            if (data && data.links) {
                this.url = _.find(data.links, function (l) { return l.rel == "self"; }).href;
                components.url = this.url;
            }

            //            components.url = this.get('parent').url() + '/' + this.id;

            this.set('components', components);
        }
    });
});