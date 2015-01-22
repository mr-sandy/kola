define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var $ = require('jquery');

    var StateBroker = function () {
        this.selected = null;
        this.active = null;
    };

    _.extend(StateBroker.prototype, {
        register: function (component) {
            component.on('all', function (eventName) {
                var self = this;
                this.handleEvent(eventName, component).then(function (proceed) {
                    self.trigger(eventName, component);
                });
            }, this);
        },

        handleEvent: function (eventName, component) {
            var d = $.Deferred();

            switch (eventName) {
                case 'selected':
                    this.handleSelected(component, d);
                    break;

                case 'active':
                    this.handleActive(component, d);
                    break;

                default:
                    d.resolve();
                    break;
            }

            return d.promise();
        },

        handleSelected: function (component, d) {
            var self = this;

            if (this.selected != null && this.selected != component) {
                this.selected.trigger('deselected');
            }

            if (component != null) {
                if (component.refreshed) {
                    this.selected = component;
                    d.resolve();
                }
                else {
                    component.fetch({ propertyListRefresh: true }).then(function () {
                        component.refreshed = true;
                        self.selected = component;
                        d.resolve();
                    });
                }
            }
            else {
                this.selected == null;
                d.resolve();
            }
        },

        handleActive: function (component, d) {
            if (this.active != null && this.active != component) {
                this.active.trigger('inactive');
            }

            this.active = component;
            d.resolve();
        }

    }, Backbone.Events);

    var stateBrokerSingleton = new StateBroker();

    return stateBrokerSingleton;
});
