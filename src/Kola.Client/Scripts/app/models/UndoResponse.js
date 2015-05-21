define(function (require) {
    "use strict";

    // ReSharper disable InconsistentNaming

    var Backbone = require('backbone');
    var _ = require('underscore');

    // ReSharper restore InconsistentNaming

    return Backbone.Model.extend({

        parse: function (response) {

            return _.extend(response,
            {
                affected: _.chain(response.links).where({ 'rel': 'affected' }).pluck('href').value(),
                subject: this.getLink(response.links, 'subject')
            });
        }
    });
});
