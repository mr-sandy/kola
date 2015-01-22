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
                this.handleEvent(eventName, component);
            }, this);
        },

        handleEvent: function (eventName, component) {
            switch (eventName) {
                case 'selected':
                    this.handleSelected(component);
                    break;

                case 'active':
                    this.handleActive(component);
                    break;
            }

            this.trigger(eventName, component);
        },

        handleSelected: function (component) {
            var self = this;

            if (this.selected != null && this.selected != component) {
                this.selected.trigger('deselected');
            }

            this.selected = component;
        },

        handleActive: function (component) {
            if (this.active != null && this.active != component) {
                this.active.trigger('inactive');
            }

            this.active = component;
        }

    }, Backbone.Events);

    var stateBrokerSingleton = new StateBroker();

    return stateBrokerSingleton;
});
