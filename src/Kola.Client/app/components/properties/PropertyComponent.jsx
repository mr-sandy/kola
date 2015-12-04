var PropertyHeaderComponent = require('app/components/properties/PropertyHeaderComponent.jsx');
var PropertyValueComponent = require('app/components/properties/PropertyValueComponent.jsx');
//var PropertyControlsComponent = require('app/components/properties/PropertyControlsComponent.jsx');
var _ = require('underscore');
var React = require('react');

module.exports = React.createClass({
    propTypes: {
        onChange: React.PropTypes.func.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired
    },

    render: function () {

        const divClass = this.state.editMode ? 'property editMode' : 'property';

        const childProps = {
            editMode: this.state.editMode,
            propertyName: this.props.propertyName,
            propertyType: this.props.propertyType,
            propertyValue: this.state.propertyValue
        };

        return (
            <div className={divClass} onClick={this.handleClick}>
                <PropertyHeaderComponent {...childProps} onPropertyValueTypeChange={this.handlePropertyValueTypeChange} />
                <PropertyValueComponent {...childProps} onEditModeChange={this.handleEditModeChange} onSubmit={this.handleSubmit} />
            </div>
        );
    },

    getInitialState: function () {
        return {
            editMode: false,
            propertyValue: this.props.propertyValue
        };
    },

    handleClick: function () {
        this.handleEditModeChange(!this.state.editMode);
    },

    handleEditModeChange: function (editMode) {
        if (this.state.editMode !== editMode) {
            this.setState({ editMode: editMode });
        }
    },

    handlePropertyValueTypeChange: function (propertyValueType) {
        if (this.state.propertyValue.type !== propertyValueType) {

            const propertyValue = propertyValueType === this.props.propertyValue.type
                ? this.props.propertyValue
                : { type: propertyValueType };

            this.setState({ propertyValue: propertyValue });
        }
    },

    handleSubmit: function (value) {
        this.props.onChange({
            propertyName: this.props.propertyName,
            propertyType: this.props.propertyType,
            propertyValue: value
        });
    }
});

//captureValueComponent: function (c) {
//    this._valueComponent = c;
//},

//handleSubmit: function () {
//    if (this.state.editMode) {
//        this.props.onChange({
//            propertyName: this.props.propertyName,
//            propertyType: this.props.propertyType,
//            propertyValue: this._valueComponent.value()
//        });
//    }
//},

//handleCancel: function () {
//    if (this.state.editMode) {
//        this.setState({
//            editMode: false,
//            propertyValue: this.props.propertyValue
//        });
//    }
//},




