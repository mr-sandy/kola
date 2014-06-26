define(function (require) {
    "use strict";

    var Atom = require('app2/models/Atom');
    var Container = require('app2/models/Container');
    var Widget = require('app2/models/Widget');

    return {
        build: function(component) {
            if (component.type == 'atom') {
                return new Atom(component, { parse: true });
            }

            if (component.type == 'container') {
                return new Container(component, { parse: true });
            }

            if (component.type == 'widget') {
                return new Widget(component, { parse: true });
            }
        }
    };
});
