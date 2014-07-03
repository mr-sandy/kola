define(function (require) {
    "use strict";

    var Backbone = require('backbone');

    return Backbone.View.extend({

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
        },

        refresh: function () {
            this.$el.html("<h1>Bang!</h1>");
        }
    });
});