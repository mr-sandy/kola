define(function (require) {
    "use strict";

    // ReSharper disable InconsistentNaming

    var Backbone = require('backbone');
    var $ = require('jquery');
    var _ = require('underscore');
    var Amendments = require('app/collections/Amendments');
    require('backbone-hypermedia');

    // ReSharper restore InconsistentNaming

    return Backbone.HypermediaModel.extend({

        links: {
            'amendments': Amendments
        },

        parse: function (response) {
            this.previewUrl = this.getLink(response.links, 'preview');

            // ReSharper disable once InconsistentNaming
            var Components = require('app/collections/Components');

            return _.extend(response,
            {
                components: new Components(response.components, { parse: true })
            });
        },

        refresh: function (componentUrls) {
            var self = this;

            var findComponent = function (componentUrl) {
                var componentPath = componentUrl ? _.without(componentUrl.split('/'), '') : [];
                return self.findChild(self, componentPath);
            };

            var fetches = _.chain(componentUrls)
                .map(findComponent)
                .invoke('fetch')
                .value();

            return $.when(fetches);
        },

        select: function (componentUrl) {

            var componentPath = componentUrl ? _.without(componentUrl.split('/'), '') : [];
            var component = this.findChild(this, componentPath);
            component.select();
        },

        findChild: function (candidate, componentPath) {

            if (componentPath.length === 0 || componentPath[0] === '') {
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

