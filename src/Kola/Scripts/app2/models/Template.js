define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Amendments = require('app2/collections/Amendments');
    require('backbone-hypermedia');

    return Backbone.HypermediaModel.extend({

        links: {
            'amendments': Amendments
        },

        parse: function (response) {
            var Components = require('app2/collections/Components');

            return _.extend(response,
            {
                components: new Components(response.components, { parse: true })
            });
        },

        refresh: function (componentUrl) {
        //TODO Start here
            alert(componentUrl);
            //            var componentPath = componentUrl
            //                    ? _.without(componentUrl.split('/'), '')
            //                    : [];
            //            var component = this._findChild(componentPath);
            //            component.fetch().then(function () {
            //                component.trigger('change');
            //            });
        }
    });
});

