define([    'app/Config',
], function (Config) {
    'use strict';

    return {
        parse: function (resp, options) {
            this.url = this.getLink(resp.links, 'self');
            this.url = this.combineUrls(Config.kolaRoot, this.getLink(resp.links, 'self'));
            return _.extend(resp,
            {
                url: this.getLink(resp.links, 'self'),
                subject: this.getLink(resp.links, 'subject'),
                undo: this.getLink(resp.links, 'undo')
            });
        }
    }
});