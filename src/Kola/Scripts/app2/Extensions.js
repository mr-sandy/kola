define([
    'jquery',
    'backbone',
    'underscore'
], function ($,
    Backbone,
    _) {
    "use strict";

    Backbone.View.prototype.navigate = function (e) {
        e.preventDefault();
        this.options.router.navigate($(e.target).attr('href'), { trigger: true });
    };

    Backbone.View.prototype.assign = function (view, selector) {
        view.setElement(selector).render();
    };

    Backbone.Model.prototype.getLink = function (links, rel) {
        var link = _.find(links, function (l) { return l.rel == rel; });

        return (link) ? link.href : '';
    };

    Backbone.View.prototype.combineUrls = urlCombine;
    Backbone.Model.prototype.combineUrls = urlCombine;
    Backbone.Collection.prototype.combineUrls = urlCombine;

    function urlCombine(url1, url2) {
        if (url1) {
            url1 = url1.replace(/\/$/, "");
        }
        if (url2) {
            url2 = url2.replace(/^\//, "");
        }
        return url1 + '/' + url2;
    }
});