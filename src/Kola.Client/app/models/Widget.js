var Backbone = require('backbone');
var _ = require('underscore');
var Component = require('app/models/Component');

module.exports = Component.extend({

    parse: function (response) {

        this.url = this.getLink(response.links, 'self');

        var Areas = require('app/collections/Areas');

        return _.extend(response,
        {
            areas: new Areas(response.areas, { parse: true })
        });
    }
});

