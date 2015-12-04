﻿var PropertyValueTypeComponent = require('app/components/properties/PropertyValueTypeComponent.jsx');
var FixedPropertyValueComponent = require('app/components/properties/FixedPropertyValueComponent.jsx');
var InheritedPropertyValueComponent = require('app/components/properties/InheritedPropertyValueComponent.jsx');
var React = require('react');

module.exports = React.createClass({

    getInitialState: function () {
        return {
            editMode: false,
            propertyValue: this.props.propertyValue
        };
    },

    render: function () {

        var divClass = this.state.editMode ? 'property editMode' : 'property';

        var valueComponent = this.state.propertyValue.type === 'fixed'
            ? <FixedPropertyValueComponent ref={this.captureValueComponent} editMode={this.state.editMode} onFastEdit={this.handleEdit} propertyType={this.props.propertyType} propertyValue={this.state.propertyValue} onSubmit={this.handleSubmit} />
            : <InheritedPropertyValueComponent ref={this.captureValueComponent} editMode={this.state.editMode} propertyType={this.props.propertyType} propertyName={this.props.propertyName} propertyValue={this.state.propertyValue} onSubmit={this.handleSubmit} />;

        return (
            <div className={divClass} onClick={this.handleEdit}>
                <div className="chrome">
                    <label className="name">{this.props.propertyName}</label>
                    <PropertyValueTypeComponent currentValue={this.state.propertyValue.type} editMode={this.state.editMode} onChange={this.handlePropertyValueTypeChange} />
                    <div style={{clear:'both'}}></div>
                </div>
                {valueComponent}
                <div className="controls">
                    <button className="submit" onClick={this.handleSubmit}><i className="fa fa-check"></i></button>
                    <button className="cancel" onClick={this.handleCancel}><i className="fa fa-times"></i></button>
                    <div style={{clear:'both'}}></div>
                </div>
            </div>
            );
    },

    captureValueComponent: function (c) {
        this._valueComponent = c;
    },

    handleEdit: function () {
        if (!this.state.editMode) {
            this.setState({ editMode: true });
        }
    },

    handleSubmit: function () {
        if (this.state.editMode) {
            this.props.onChange({
                propertyName: this.props.propertyName,
                propertyType: this.props.propertyType,
                propertyValue: this._valueComponent.value()
            });
        }
    },

    handleCancel: function () {
        if (this.state.editMode) {
            this.setState({
                editMode: false,
                propertyValue: this.props.propertyValue
            });
        }
    },

    handlePropertyValueTypeChange: function (propertyValueType) {
        if (this.state.propertyValue.type !== propertyValueType) {

            var propertyValue = propertyValueType === this.props.propertyValue.type
                ? this.props.propertyValue
                : { type: propertyValueType };

            this.setState({ propertyValue: propertyValue });
        }
    }
});



