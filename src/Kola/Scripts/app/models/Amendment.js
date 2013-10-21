define(function () {
    'use strict';

    return {
        parse: function (resp, xhr) {
            var subject = _.find(resp.links, function (l) { return l.rel == "subject"; }).href;
            var url = _.find(resp.links, function (l) { return l.rel == "self"; }).href;
            var undoLink = _.find(resp.links, function (l) { return l.rel == "undo"; });
            return _.extend(resp,
            {
                url: url,
                subject: subject,
                undo: undoLink ? undoLink.href : null 
            });
        }
    }
});