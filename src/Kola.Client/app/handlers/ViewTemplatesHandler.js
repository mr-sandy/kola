var $ = require('jquery');
var ViewTemplatesView = require('app/views/ViewTemplatesView');

module.exports = {
    execute: function (options) {

        var d = $.Deferred();

        //            var registrations = new Registrations([], { employeeId: config.employeeId });

        //            registrations.fetch().then(function () {

        //                options.breadcrumbs.reset([{ label: 'Training'}]);

        d.resolve(new ViewTemplatesView({
            //                    collection: registrations,
            router: options.router
        }));
        //            });

        return d.promise();
    }
};
