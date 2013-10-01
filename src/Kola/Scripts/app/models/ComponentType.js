define([
    'backbone',
    'underscore'
], function (Backbone,
    _) {

    'use strict';

    return Backbone.Model.extend({

        parse: function (resp, options) {

            var id = _.find(resp.links, function (l) { return l.rel == 'self' }).href;

            return _.extend(resp, { id: id });
        }
    });
});