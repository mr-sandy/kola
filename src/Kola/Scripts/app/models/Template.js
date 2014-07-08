define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Amendments = require('app/collections/Amendments');
    require('backbone-hypermedia');

    return Backbone.HypermediaModel.extend({

        links: {
            'amendments': Amendments
        },

        parse: function (response) {
            var Components = require('app/collections/Components');

            return _.extend(response,
            {
                components: new Components(response.components, { parse: true })
            });
        },

        refresh: function (componentUrls) {
            var self = this;

            _.each(componentUrls, function (componentUrl) {

                var componentPath = componentUrl
                                ? _.without(componentUrl.split('/'), '')
                                : [];

                self.findChild(self, componentPath).fetch();
            });
        },

        findChild: function (candidate, componentPath) {
            if (componentPath.length == 0 || componentPath[0] == '') {
                return candidate;
            }

            var index = componentPath[0];
            var remainder = componentPath.slice(1);

            var collection = candidate.get('components') || candidate.get('areas');

            var item = collection.at(index);

            return this.findChild(item, remainder);
        }
    });
});

