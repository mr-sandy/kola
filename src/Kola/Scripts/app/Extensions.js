define([
    'jquery',
    'backbone'
], function ($,
    Backbone) 
{
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

    Backbone.View.prototype.assign = function (view, selector) {
        view.setElement(this.$(selector)).render();
    };
});