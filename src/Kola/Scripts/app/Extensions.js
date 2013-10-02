define([
    'jquery',
    'backbone'
], function ($,
    Backbone) {
    "use strict";

    Backbone.View.prototype.canClose = function () {
        return true;
    };

    Backbone.View.prototype.close = function () {
        if (this.canClose()) {
            this.remove();
            if (this.onClose) {
                this.onClose();
            }
            return true;
        }
        return false;
    };

    Backbone.View.prototype.navigate = function (e) {
        e.preventDefault();
        this.options.router.navigate($(e.target).attr('href'), { trigger: true });
    };

    Backbone.View.prototype.assign = function (view, selector) {
        view.setElement(selector).render();
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