define([
    'backbone',
    'app/models/Amendment',
    'app/models/ApplyAmendmentRequest'
], function (Backbone,
    Amendment,
    ApplyAmendmentRequest) {
    'use strict';

    return Backbone.Collection.extend({

        model: Amendment,

        apply: function () {
            this.addAmendment(new ApplyAmendmentRequest());
        },

        addAmendment: function (amendment) {
            var self = this;
            this.add(amendment);
            amendment.save('jam', 'bread');
        }
    });
});