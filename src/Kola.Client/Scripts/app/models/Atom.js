define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Component = require('app/models/Component');

    return Component.extend({

        parse: function (response) {

            this.url = this.getLink(response.links, 'self');
            this.previewUrl = this.getLink(response.links, 'preview');
            this.trigger('jam');
            return response;
        }
    });
});
