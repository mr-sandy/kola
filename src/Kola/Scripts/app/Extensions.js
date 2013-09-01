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
        view.setElement(this.$(selector)).render();
    };
});