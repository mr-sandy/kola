define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.Model.extend({

        parse: function (response) {

            return _.extend(response,
            {
                //                url: this.getLink(response.links, 'self'),
                subject: this.getLink(response.links, 'subject')
                //                undo: this.getLink(response.links, 'undo')
            });
        }
    });
});
