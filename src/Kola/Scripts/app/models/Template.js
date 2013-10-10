define([
    'backbone',
    'app/models/Component',
    'app/models/CompositeComponent',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/models/DeleteComponentAmendment',
    'app/models/ApplyAmendmentRequest',
    'app/collections/Components',
    'app/collections/Amendments'
], function (
    Backbone,
    Component,
    CompositeComponent,
    AddComponentAmendment,
    MoveComponentAmendment,
    DeleteComponentAmendment,
    ApplyAmendmentRequest,
    Components,
    Amendments) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            componentPath: '',

            initialize: function () {
                var self = this;

                _.bindAll(this, '_updateModel', '_showFailure');

                if (!Component) { Component = require('app/models/Component'); }

                var components = new Components([], { model: Component });
                components.template = this;
                this.set('components', components);

                this.set('amendments', new Amendments([], { url: function () { return this.combineUrls(self.url, '_amendments') } }));
            },

            parse: function (resp, xhr) {

                this.get('components').set(resp.components, { parse: true });

                return _.omit(resp, 'components');
            },

            addComponent: function (args) {
                var amendment = new AddComponentAmendment(args);
                this.get('amendments').add(amendment);
                amendment.save().then(this._updateModel).fail(this._showFailure);
            },

            moveComponent: function (args) {
                var amendment = new MoveComponentAmendment(args);
                this.get('amendments').add(amendment);
                amendment.save().then(this._updateModel);
            },

            deleteComponent: function (args) {
                var amendment = new DeleteComponentAmendment(args);
                this.get('amendments').add(amendment);
                amendment.save().then(this._updateModel);
            },

            applyAmendments: function () {
                var applyAmendmentRequest = new ApplyAmendmentRequest();
                this.get('amendments').add(applyAmendmentRequest);
                applyAmendmentRequest.save();
            },

            _updateModel: function (data) {
                var componentPath = _.find(data.links, function (l) { return l.rel == "componentPath"; }).href;
                var component = this._findChild(componentPath.split('/'));
                component.set(component.parse(data));
                component.trigger('updated');
            },

            _showFailure: function (data) {
                alert('fail fail fail');
            }
        },
        CompositeComponent));
});