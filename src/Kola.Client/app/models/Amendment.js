var Backbone = require('backbone');
var _ = require('underscore');

module.exports = Backbone.Model.extend({

    parse: function (response) {

        return _.extend(response,
        {
            affected: _.chain(response.links).where({ 'rel': 'affected' }).pluck('href').value(),
            subject: this.getLink(response.links, 'subject')
        });
    }
});
