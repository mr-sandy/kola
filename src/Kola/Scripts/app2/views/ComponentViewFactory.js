define(function (require) {
    "use strict";

    var AtomView = require('app2/views/AtomView');
    var ContainerView = require('app2/views/ContainerView');
    var WidgetView = require('app2/views/WidgetView');

    return {
        build: function(component, amendmentBroker) {
            var componentType = component.get('type');

            if (componentType == 'atom') {
                return new AtomView({ model: component });
            }

            if (componentType == 'container') {
                return new ContainerView({ model: component,
                    amendmentBroker: amendmentBroker
                });
            }

            if (componentType == 'widget') {
                return new WidgetView({ model: component,
                    amendmentBroker: amendmentBroker
                });
            }
        }
    };
});
