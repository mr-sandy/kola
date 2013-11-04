define([
    'backbone',
    'app/Config',
], function (
    Backbone,
    Config) {
    'use strict';

    return Backbone.Model.extend({

        parse: function (resp, options) {
            this.url = this.combineUrls(Config.kolaRoot, this.getLink(resp.links, 'self'));
            return _.extend(resp,
            {
                url: this.getLink(resp.links, 'self'),
                subject: this.getLink(resp.links, 'subject'),
                undo: this.getLink(resp.links, 'undo')
            });
        }
    });
});