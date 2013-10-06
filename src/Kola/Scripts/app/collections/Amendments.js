define([
    'backbone',
    'app/models/Amendment'
], function (Backbone,
    Amendment) {

    'use strict';

    return Backbone.Collection.extend({

        model: Amendment

    });
});