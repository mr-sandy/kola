var _ = require('underscore');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired,
        onBlur: React.PropTypes.func.isRequired,
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {
        return <div className={`value ${this.props.propertyType}`} ref={this.captureElement} onClick={this.handleClick}></div>;
    },

    captureElement(el) {
        this._element = el;
    },

    componentDidUpdate: function () {
        this.renderFromPlugin();
    },

    componentDidMount: function () {
        this.renderFromPlugin();
    },

    handleChange: function (value) {
        this.props.onChange({
            type: 'fixed',
            value: value
        });
    },

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
        }
    },

    renderFromPlugin() {
        var propertyType = this.props.propertyType;

        this.editor = _.find(kola.propertyEditors, function (ed) {
            return ed.propertyType === propertyType;
        });

        this.editor.render({
            element: this._element,
            value: this.props.propertyValue.value,
            editMode: this.props.editMode,
            onChange: this.handleChange,
            onSubmit: this.props.onSubmit,
            onBlur: this.props.onBlur
        });

    }
});
