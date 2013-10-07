define([
    'backbone',
    'app/models/Component',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/models/ApplyAmendmentRequest',
    'app/collections/Components',
    'app/collections/Amendments'
], function (
    Backbone,
    Component,
    AddComponentAmendment,
    MoveComponentAmendment,
    ApplyAmendmentRequest,
    Components,
    Amendments) {
    'use strict';

    return Backbone.Model.extend(
    {
        initialize: function () {
            var self = this;

            if (!Component) { Component = require('app/models/Component'); }

            this.set('amendments', new Amendments([], { url: function () { return this.combineUrls(self.url, '_amendments') } }));
            this.set('components', new Components([], { model: Component }));

            this.get('components').on(
            {
                "addComponent": this.addComponent,
                "moveComponent": this.moveComponent
            }, this);
        },

        parse: function (resp, xhr) {

            this.get('components').reset(resp.components, { parse: true });

            return _.omit(resp, 'components');
        },

        componentPath: '',

        addComponent: function (args) {
            var self = this;
            var amendment = new AddComponentAmendment(args);
            this.get('amendments').add(amendment);
            amendment.save()
            .then(function (data) {
                var componentPath = _.find(data.links, function (l) { return l.rel == "componentPath"; }).href;
                var component = self.findChild(componentPath.split('/'));
                component.parse(data);
            });
        },

        moveComponent: function (args) {
            var self = this;
            var amendment = new MoveComponentAmendment(args);
            this.get('amendments').add(amendment);
            amendment.save()
            .then(function (data) {
                alert(data);
            });
        },

        applyAmendments: function () {
            var applyAmendmentRequest = new ApplyAmendmentRequest();
            this.get('amendments').add(applyAmendmentRequest);
            applyAmendmentRequest.save();
        },

        findChild: function (componentPath) {
            if (componentPath.length == 0) {
                return this;
            }

            var index = componentPath[0];
            var remainder = componentPath.slice(1);
            var components = this.get('components');

            if (index >= components.length) {
                throw "Component index outside bounds";
            }

            var component = components.at(index);

            if (remainder.length == 0) {
                return component;
            }

            return component.findChild(remainder);
        }
    });
});