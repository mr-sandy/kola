var React = require('react');
var ReactDOM = require('react-dom');

module.exports = {
    register: function(type, editor) {
        kola.propertyEditors.push({
            propertyType: type,

            render: function(el, value, editMode, submitHandler, fastEditHandler) {

                var model = {
                    value: value,
                    editMode: editMode,
                    onSubmit: submitHandler,
                    onFastEdit: fastEditHandler,
                    ref: this.captureComponent.bind(this)
                };

                ReactDOM.render(React.createElement(editor, model), el);
            },

            captureComponent: function(c) {
                this._component = c;
            },

            value: function() {
                return this._component.value();
            }
        });
    }
};
