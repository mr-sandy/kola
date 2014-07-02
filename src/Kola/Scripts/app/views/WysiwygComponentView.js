define(function (require) {
    "use strict";

    var Backbone = require('backbone');

    return Backbone.View.extend({

        initialize: function (options) {
            this.model.on('sync', function () { console.log(this.model.url); }, this);
        }

    });
});