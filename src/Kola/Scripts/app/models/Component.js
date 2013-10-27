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

            parse: function (resp, options) {

                var components = new Components(resp.components, { parse: true });
                this.set('components', components);

                var componentPath = _.find(resp.links, function (l) { return l.rel == "self"; }).href;
                this.url = this.combineUrls(Config.kolaRoot, componentPath);

                resp = _.extend(resp,
                            {
                                'componentPath': _.find(resp.links, function (l) { return l.rel == "componentPath"; }).href,
                                'path': this.url
                            });

                return _.omit(resp, 'components', 'amendments');
            }
        },
        CompositeComponent));
});