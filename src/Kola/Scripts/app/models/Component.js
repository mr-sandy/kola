define([
    'backbone',
    'app/models/ComponentCollection'
], function (
    Backbone,
    ComponentCollection) {
    "use strict";

    return Backbone.Model.extend(ComponentCollection).extend(
        {
            initialize: function () {
                this.baseInitialize();
            },

            parse: function (resp, xhr) {
                this.baseParse(resp);

                this.set(resp);
            }
        });
});