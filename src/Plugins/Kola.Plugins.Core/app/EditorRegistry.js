var _ = require('underscore');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = {
    register: function(type, editor) {

        kola.propertyEditors.push({
            propertyType: type,

            render: function (opts) {

                var props = _.pick(opts, 'value', 'editMode', 'onChange', 'onSubmit', 'onBlur');

                ReactDOM.render(React.createElement(editor, props), opts.element);
            }
        });
    }
};
