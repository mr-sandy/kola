define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Amendment = require('app2/models/Amendment');

    return Backbone.Collection.extend({

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

        parse: function (response, options) {

            this.url = options.url;
            return response;
        }
    });
});
