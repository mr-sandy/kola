define(function () {
    'use strict';

    return {
        parse: function (resp, options) {
            return _.extend(resp,
            {
                url: this.getLink(resp.links, 'self'),
                subject: this.getLink(resp.links, 'subject'),
                undo: this.getLink(resp.links, 'undo')
            });
        }
    }
});