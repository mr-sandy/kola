define(function (require) {
    "use strict";

    // ReSharper disable InconsistentNaming

    var $ = require('jquery');
    var EditTemplateView = require('app/views/EditTemplateView');
    var ComponentTypes = require('app/collections/ComponentTypes');
    var Template = require('app/models/Template');

    // ReSharper restore InconsistentNaming

    return {
        execute: function (options, templatePath) {

            var d = $.Deferred();

            var componentTypes = new ComponentTypes();

            var template = new Template();

            templatePath = templatePath !== null ? templatePath : '';
            template.url = '/_kola/templates/' + templatePath;

            $.when(componentTypes.fetch(), template.fetch()).then(function () {

                template.listenTo(template.amendments, 'sync', function (amendment) {
                    var affected = amendment.get('affected');
                    var subject = amendment.get('subject');

                    template.refresh(affected).then(setTimeout(function () { template.select(subject); }, 200));
                });

                template.listenTo(template.amendments, 'undo', function (undoResponse) {
                    var affected = undoResponse.get('affected');
                    var subject = undoResponse.get('subject');

                    template.refresh(affected).then(setTimeout(function () { template.select(subject); }, 200));
                });

                d.resolve(new EditTemplateView({
                    componentTypes: componentTypes,
                    model: template,
                    router: options.router
                }));
            });

            return d.promise();
        }
    };
});
