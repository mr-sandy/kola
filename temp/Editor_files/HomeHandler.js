define(function (require) {
    "use strict";

    var $ = require('jquery');
    var HomeView = require('app/views/HomeView');

    return {
        execute: function (options) {

            var d = $.Deferred();

//            var registrations = new Registrations([], { employeeId: config.employeeId });

//            registrations.fetch().then(function () {

//                options.breadcrumbs.reset([{ label: 'Training'}]);

                d.resolve(new HomeView({
//                    collection: registrations,
                    router: options.router
                }));
//            });

            return d.promise();
        }
    };
});
