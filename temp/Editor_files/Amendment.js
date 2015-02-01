define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        parse: function (response) {

            return _.extend(response,
            {
                subjects: _.chain(response.links).where({ 'rel': 'subject' }).pluck('href').value()
            });
        }
    });
});
