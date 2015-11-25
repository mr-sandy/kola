var Backbone = require('backbone');
var _ = require('underscore');

module.exports = Backbone.Model.extend({
    parse: function (resp, options) {
        return _.extend(resp, { id: this.getLink(resp.links, 'self') });
    }
});
