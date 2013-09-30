define([
    'app/models/Component',
    'app/collections/Components'
], function (
    Component,
    Components) {
    "use strict";

    return Backbone.Model.extend(
    {
        initialize: function () {
            _.bindAll(this, 'collectionUrl');
            this.set("components", new Components());
        },

        parse: function (resp, xhr) {
            var components = _.map(resp.components, function (value) { return new Component(value); });
            //this.get("components").url = _.find(resp.links, function (l) { return l.rel == "self"; }).href + '/_components';

            //            this.url = _.find(resp.links, function (l) { return l.rel == "self"; }).href;
            this.get("components").reset(components);

            this.get("components").url = this.collectionUrl;

            return _.omit(resp, "components");
        },

        collectionUrl: function () {
            return this.url() + "/_components";
        },

        url: function () {
            return this.id;
        },

        urlRoot: "/"
    });
});