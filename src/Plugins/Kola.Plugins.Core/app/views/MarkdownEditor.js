var $ = require('jquery');
var MarkdownEditor = require('app/components/MarkdownEditorComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = {
    propertyType: 'markdown',

    render: function (el, value, editMode) {

        var model = {
            value: value,
            editMode: editMode,
            ref: this.captureComponent.bind(this)
        };

        ReactDOM.render(React.createElement(MarkdownEditor, model), el);
    },

    captureComponent: function (c) {
        this._component = c;
    },

    value: function () {
        return this._component.value();
    }
}