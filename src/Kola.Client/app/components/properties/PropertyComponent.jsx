var PropertyHeaderComponent = require('app/components/properties/PropertyHeaderComponent.jsx');
var PropertyValueComponent = require('app/components/properties/PropertyValueComponent.jsx');
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
                <PropertyValueComponent {...childProps} onSubmit={this.handleSubmit} onBlur={this.handlePropertyValueBlur} onChange={this.handlePropertyValueChange} />
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
        if (this.state.editMode) {
            this.handleSubmit();
        }
        else {
            this.handleEditModeChange(true);
        }
    },

    handleEditModeChange: function (editMode) {
        if (this.state.editMode !== editMode) {
            this.setState({ editMode: editMode });
        }
    },

    handlePropertyValueChange: function (propertyValue) {
        this.setState({ propertyValue: propertyValue });
    },

    handlePropertyValueBlur: function () {
        if (this.state.propertyValue !== this.props.propertyValue) {
            this.handleSubmit();
        }
    },

    handlePropertyValueTypeChange: function (propertyValueType) {
        if (this.state.propertyValue.type !== propertyValueType) {

            const propertyValue = propertyValueType === this.props.propertyValue.type
                ? this.props.propertyValue
                : { type: propertyValueType };

            if (propertyValue.type === 'inherited' && !propertyValue.key) {
                propertyValue.key = this.props.propertyName;
            }

            this.setState({ propertyValue: propertyValue });
        }
    },

    handleSubmit: function () {
        if (this.state.editMode) {
            this.setState({ editMode: false });

            if (this.state.propertyValue !== this.props.propertyValue) {
                this.props.onChange({
                    propertyName: this.props.propertyName,
                    propertyType: this.props.propertyType,
                    propertyValue: this.state.propertyValue
                });
            }
        }
    }
});


//handleCancel: function () {
//    if (this.state.editMode) {
//        this.setState({
//            editMode: false,
//            propertyValue: this.props.propertyValue
//        });
//    }
//},




