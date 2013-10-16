define(['backbone',
], function (Backbone) {
    'use strict';

    return Backbone.Model.extend(
    {
        parse: function (resp, xhr) {
            return resp;
        }

    });
});