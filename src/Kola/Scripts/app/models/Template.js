define([
    'backbone',
    'app/models/Component',
    'app/models/CompositeComponent',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/models/DeleteComponentAmendment',
    'app/models/ApplyAmendmentRequest',
    'app/models/UndoAmendmentRequest',
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
    UndoAmendmentRequest,
    Components,
    Amendments) {
    'use strict';

    return Backbone.Model.extend(
    _.extend(
        {
            componentPath: '',

            initialize: function () {
                var self = this;

//                _.bindAll(this, '_updateModel', '_showFailure');

                if (!Component) { Component = require('app/models/Component'); }

                var components = new Components([], { model: Component });
                components.template = this;
                this.set('components', components);
            },

            parse: function (resp, xhr) {

                this.get('components').set(resp.components, { parse: true });
                this.amendmentsUrl = _.find(resp.links, function (l) { return l.rel == "amendments"; }).href;
                return _.omit(resp, 'components');
            }

            //            addComponent: function (args) {
            //                var amendment = new AddComponentAmendment(args);
            //                this.get('amendments').add(amendment);
            //                amendment.save().then(this._updateModel).fail(this._showFailure);
            //            },

            //            moveComponent: function (args) {
            //                var amendment = new MoveComponentAmendment(args);
            //                this.get('amendments').add(amendment);
            //                amendment.save().then(this._updateModel);
            //            },

            //            deleteComponent: function (args) {
            //                var amendment = new DeleteComponentAmendment(args);
            //                this.get('amendments').add(amendment);
            //                amendment.save().then(this._updateModel);
            //            },

            //            undoAmendment: function () {
            //                var undoAmendmentRequest = new UndoAmendmentRequest();
            //                this.get('amendments').add(undoAmendmentRequest);
            //                undoAmendmentRequest.save().then(this._updateModel);
            //            },

            //            applyAmendments: function () {
            //                var applyAmendmentRequest = new ApplyAmendmentRequest();
            //                this.get('amendments').add(applyAmendmentRequest);
            //                applyAmendmentRequest.save();
            //            },

            //            _updateModel: function (data) {
            //                var componentPath = _.find(data.links, function (l) { return l.rel == "subject"; }).href;
            //                var component = this._findChild(componentPath.split('/'));
            //                //                component.set(component.parse(data));
            //                component.fetch().then(function () {
            //                    component.trigger('change');
            //                });
            //            },

            //            _showFailure: function (data) {
            //                alert('fail fail fail');
            //            }
        },
        CompositeComponent));
});