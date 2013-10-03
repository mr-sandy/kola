define([
    'backbone',
    'underscore'
], function (
    Backbone,
    _) {
    'use strict';

    return Backbone.Model.extend(
    {
        url: function () {
            return this.combineUrls(_.result(this.collection, 'url'), 'moveComponent')
        }
    });
});