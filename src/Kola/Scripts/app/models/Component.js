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

                this.components = new Components(resp.components, { parse: true });

                this.url = this.combineUrls(Config.kolaRoot, this.getLink(resp.links, 'self'));

                resp = _.extend(resp,
                            {
                                'componentPath': this.getLink(resp.links, 'componentPath')
                            });

                return _.omit(resp, 'components');
            }
        },
        CompositeComponent));
});