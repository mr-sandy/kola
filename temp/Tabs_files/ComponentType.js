define(function (require) {
    "use strict";

    var Backbone = require('backbone');

    return Backbone.Model.extend({
        parse: function (resp, options) {
            return _.extend(resp, { id: this.getLink(resp.links, 'self') });
        }
    });
});
