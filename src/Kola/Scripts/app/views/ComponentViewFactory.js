﻿define(function (require) {
    "use strict";

    var AtomView = require('app/views/AtomView');
    var ContainerView = require('app/views/ContainerView');
    var WidgetView = require('app/views/WidgetView');
    var AreaView = require('app/views/AreaView');
    var BlockComponentView = require('app/views/BlockComponentView');

    return {
        build: function(component, amendmentBroker) {
            var componentType = component.get('type');

            if (componentType == 'atom') {
                return new AtomView({ model: component });
            }

            if (componentType == 'container') {
                return new BlockComponentView({ model: component,
                    amendmentBroker: amendmentBroker,
                    childAccessor: 'components',
                    sortable: true
                });
            }

            if (componentType == 'widget') {
                return new WidgetView({ model: component,
                    amendmentBroker: amendmentBroker
                });
            }

            if (componentType == 'area') {
                return new AreaView({ model: component,
                    amendmentBroker: amendmentBroker
                });
            }
        }
    };
});
