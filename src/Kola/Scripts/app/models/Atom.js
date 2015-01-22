define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var stateBroker = require('app/views/StateBroker');

    return Backbone.Model.extend({

        initialize: function () {
            stateBroker.register(this);
        },

        parse: function (response) {

            this.url = this.getLink(response.links, 'self');
            this.previewUrl = this.getLink(response.links, 'preview');

            return response;
        }
    });
});
