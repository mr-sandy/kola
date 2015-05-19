define(function (require) {
    "use strict";

    var AtomView = require('app/views/AtomView');
    var ContainerView = require('app/views/ContainerView');
    var WidgetView = require('app/views/WidgetView');
    var AreaView = require('app/views/AreaView');

    return {
        build: function (component, amendmentBroker) {
            var componentType = component.get('type');

            if (componentType === 'atom') {
                return new AtomView({
                    model: component,
                    amendmentBroker: amendmentBroker
                });
            }

            if (componentType === 'container') {
                return new ContainerView({
                    model: component,
                    amendmentBroker: amendmentBroker
                });
            }

            if (componentType === 'widget') {
                return new WidgetView({
                    model: component,
                    amendmentBroker: amendmentBroker
                });
            }

            if (componentType === 'area') {
                return new AreaView({
                    model: component,
                    amendmentBroker: amendmentBroker
                });
            }
        }
    };
});
