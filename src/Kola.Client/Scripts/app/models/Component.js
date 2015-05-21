define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var stateBroker = require('app/views/StateBroker');

    return Backbone.Model.extend({

        initialize: function () {
            stateBroker.register(this);
            this.selected = false;
        },

        toggleSelected: function () {
            this.selected = !this.selected;
            if (this.selected) {
                this.trigger('selected');
            }
            else {
                this.trigger('deselected');
            }
        },

        select: function () {
            if (!this.selected) {
                this.selected = true;
                this.trigger('selected');
            }
        },

        deselect: function () {
            if (this.selected) {
                this.selected = false;
                this.trigger('deselected');
            }
        },

        activate: function () {
            this.trigger('active');
        },

        deactivate: function () {
            this.trigger('inactive');
        }
    });
});
