var _ = require('underscore');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = {
    register: function(type, editor, settings) {

        window.kola.propertyEditors.push({
            propertyType: type,

            render: function (opts) {

                const props = _.chain(opts)
                    .pick('value', 'editMode', 'onChange', 'onCancel')
                    .extend(settings)
                    .value();

                ReactDOM.render(React.createElement(editor, props), opts.element);
            }
        });
    }
};
