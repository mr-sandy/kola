define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        select: function (coords) {
            this.set(_.extend(coords, { mode: 'selected' }));
        },

        deselect: function () {
            this.set({ mode: 'deselected' });
        },

        highlight: function (coords) {
            //if (this.get('mode') !== 'selected') {
                this.set(_.extend(coords, { mode: 'highlighted' }));
            //}
        }
    });
});
