define(function (require) {
    "use strict";

    var $ = require('jquery');
    var EditTemplateView = require('app2/views/EditTemplateView');

    return {
        execute: function (options) {

            var d = $.Deferred();

            //            var registrations = new Registrations([], { employeeId: config.employeeId });

            //            registrations.fetch().then(function () {

            //                options.breadcrumbs.reset([{ label: 'Training'}]);

            d.resolve(new EditTemplateView({
                //                    collection: registrations,
                router: options.router
            }));
            //            });

            return d.promise();
        }
    };
});
