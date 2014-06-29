define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        parse: function (response) {

            this.url = this.getLink(response.links, 'self');

            return response;
        }
    });
});
