define(function () {
    'use strict';

    return {
        _findChild: function (componentPath) {
            if (componentPath.length == 0 || componentPath[0] == '') {
                return this;
            }

            var index = componentPath[0];
            var remainder = componentPath.slice(1);

            if (index >= this.components.length) {
                throw "Component index outside bounds";
            }

            var component = this.components.at(index);

            if (remainder.length == 0) {
                return component;
            }

            return component._findChild(remainder);
        }
    }
});