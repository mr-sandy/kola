define(function () {
    'use strict';

    return {
        parse: function (resp, xhr) {
            this.subject = _.find(resp.links, function (l) { return l.rel == "subject"; }).href;
            this.url = _.find(resp.links, function (l) { return l.rel == "self"; }).href;
            return resp;
        }
    }
});