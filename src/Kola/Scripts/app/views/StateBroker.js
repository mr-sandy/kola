define(function (require) {
    "use strict";

    var _ = require('underscore');
    require('jqueryui');

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
        }
    });

    return StateBroker;
});
