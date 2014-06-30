define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        parse: function (response) {

            var Components = require('app2/collections/Components');

            return _.extend(response,
            {
                components: new Components(response.components, { parse: true })
            });
        }
    });
});
