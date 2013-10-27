define([
    'backbone',
    'underscore'
], function (Backbone,
    _) {

    'use strict';

    return Backbone.Model.extend({

        parse: function (resp, options) {
            return _.extend(resp, { id: this.getLink(resp.links, 'self') });
        }
    });
});