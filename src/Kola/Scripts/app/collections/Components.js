define([
    'backbone'
], function (Backbone) {

    'use strict';
    var Component;

    return Backbone.Collection.extend({

        model: function (attrs, options) {
            if (!Component) { Component = require('app/models/Component'); }

            return new Component(attrs, options);
        }
    });
});