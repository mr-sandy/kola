define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Amendment = require('app/models/Amendment');

    return Backbone.Collection.extend({

        parse: function (response, options) {

            if (options.url) {
                this.url = options.url;
            }

            return response;
        },

        addComponent: function (componentType, targetPath) {

            var amendment = new Amendment({
                componentType: componentType,
                targetPath: targetPath
            });

            amendment.url = this.combineUrls(this.url, 'addComponent');

            this.add(amendment);

            amendment.save();
        },

        moveComponent: function (sourcePath, targetPath) {
            var amendment = new Amendment({
                sourcePath: sourcePath,
                targetPath: targetPath
            });

            amendment.url = this.combineUrls(this.url, 'moveComponent');

            this.add(amendment);

            amendment.save();
        },

        applyAmendments: function () {
            var self = this;
            var amendment = new Amendment();

            amendment.url = this.combineUrls(this.url, 'apply');

            amendment.save().then(function () { self.fetch({ reset: true }); });
        }
    });
});
