define(function (require) {
    "use strict";

    var Atom = require('app/models/Atom');
    var Container = require('app/models/Container');
    var Widget = require('app/models/Widget');

    return {
        build: function(component) {
            if (component.type === 'atom') {
                return new Atom(component, { parse: true });
            }

            if (component.type === 'container') {
                return new Container(component, { parse: true });
            }

            if (component.type === 'widget') {
                return new Widget(component, { parse: true });
            }
        }
    };
});
