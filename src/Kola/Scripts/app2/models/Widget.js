define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        parse: function (response) {

            var Areas = require('app2/collections/Areas');

            return _.extend(response,
            {
                areas: new Areas(response.areas, { parse: true })
            });
        }
    });
});
