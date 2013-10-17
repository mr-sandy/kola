define([
    'backbone',
    'underscore',
    'app/models/Amendment',
], function (
    Backbone,
    _,
    Amendment) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            url: function () {
                return this.combineUrls(_.result(this.collection, 'url'), 'moveComponent')
            }
        },
        Amendment));
});