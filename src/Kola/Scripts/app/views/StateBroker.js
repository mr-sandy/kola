define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    var StateBroker = function () {
        _.bindAll(this, 'select');
    };

    _.extend(StateBroker.prototype, {

        select: function (component) {
            if (this.selected) {
                this.selected.trigger('deselected');
            }

            if (this.selected == component) {
                this.selected = null;
            }
            else {
                this.selected = component;
                this.selected.trigger('selected');
            }

            this.trigger('change');
        }
    }, Backbone.Events);

    return StateBroker;
});
