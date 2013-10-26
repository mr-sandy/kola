define([
    'backbone',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/models/DeleteComponentAmendment',
    'app/models/ApplyAmendmentRequest',
], function (Backbone,
    AddComponentAmendment,
    MoveComponentAmendment,
    DeleteComponentAmendment,
    ApplyAmendmentRequest) {
    'use strict';

    return Backbone.Collection.extend({

        //model: Amendment,

        model: function (attrs, options) {
            switch (attrs.type) {
                case 'Add Component':
                    return new AddComponentAmendment(attrs, options);
                case 'Move Component':
                    return new MoveComponentAmendment(attrs, options);
                case 'Delete Component':
                    return new DeleteComponentAmendment(attrs, options);
            }

            return null;
        },

        addComponent: function (args) {
            var amendment = new AddComponentAmendment(args);
            this.add(amendment);
            amendment.save();
        },

        moveComponent: function (args) {
            var amendment = new MoveComponentAmendment(args);
            this.add(amendment);
            amendment.save();
        },

        deleteComponent: function (args) {
            var amendment = new DeleteComponentAmendment(args);
            this.add(amendment);
            amendment.save();
        },

        apply: function () {
            var self = this;
            var request = new ApplyAmendmentRequest();
            this.add(request);
            request.save();
        }
    });
});