var _ = require('underscore');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        const divClasses = 'value ' + this.props.propertyType;
        return <div className={divClasses} ref={this.captureElement} onClick={this.handleClick}></div>;
    },

    captureElement(el) {
        this._element = el;
    },

    componentDidMount: function () {
        var propertyType = this.props.propertyType;

        this.editor = _.find(kola.propertyEditors, function (ed) {
            return ed.propertyType === propertyType;
        });

        this.componentDidUpdate();
    },

    componentDidUpdate: function () {
        this.editor.render({
            element: this._element,
            value: this.props.propertyValue.value,
            editMode: this.props.editMode,
            onChange: this.handleChange
        });
    },

    handleChange: function (value) {

        value = value ? value : '';

        if (this.props.propertyValue.value !== value) {
            this.props.onChange({
                type: 'fixed',
                value: value
            });
        }
    },

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
        }
    }
});
