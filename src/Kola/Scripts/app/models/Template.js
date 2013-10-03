﻿define([
    'backbone',
    'app/models/Component',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/collections/Components',
    'app/collections/Amendments'
], function (
    Backbone,
    Component,
    AddComponentAmendment,
    MoveComponentAmendment,
    Components,
    Amendments) {
    'use strict';

    return Backbone.Model.extend(
    {
        initialize: function () {
            var components = new Components();
            components.on(
            {
                "addComponent": this.addComponent,
                "moveComponent": this.moveComponent
            }, this);

            this.set('components', components);
            var self = this;
            this.set('amendments', new Amendments([], { url: function () { return this.combineUrls(self.url, '_amendments') } }));
        },

        parse: function (resp, xhr) {

            var components = _.map(resp.components, function (value) {
                return new Component(value);
            });

            this.get('components').reset(components);

            return _.omit(resp, 'components');
        },

        componentPath: '',

        addComponent: function (args) {
            var amendment = new AddComponentAmendment(args);
            this.get('amendments').add(amendment);
            amendment.save();
        },

        moveComponent: function (args) {
            var amendment = new MoveComponentAmendment(args);
            this.get('amendments').add(amendment);
            amendment.save();
        }
    });
});