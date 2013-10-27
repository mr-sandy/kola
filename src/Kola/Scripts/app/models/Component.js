define([
    'backbone',
    'app/Config',
    'app/models/CompositeComponent',
    'app/collections/Components'
], function (
    Backbone,
    Config,
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
                    components = new Components();
                    this.set('components', components);
                }

                return components;
            }

        },
        CompositeComponent));
});