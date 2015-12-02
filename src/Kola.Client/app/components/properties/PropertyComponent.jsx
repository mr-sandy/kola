var PropertyValueTypeComponent = require('app/components/properties/PropertyValueTypeComponent.jsx');
var FixedPropertyValueComponent = require('app/components/properties/FixedPropertyValueComponent.jsx');
var InheritedPropertyValueComponent = require('app/components/properties/InheritedPropertyValueComponent.jsx');
var React = require('react');

var PropertyName = (props) => {
    return <label className="name">{props.name}</label>;
}

var PropertyComponent = React.createClass({

    getInitialState: function () {
        return {
            editMode: false,
            propertyValueType: this.props.propertyValue.type
        };
    },

    render: function () {

        var divClass = this.state.editMode ? 'property editMode' : 'property';

        var valueComponent = this.state.propertyValueType === 'fixed'
            ? <FixedPropertyValueComponent ref={this.captureValueElement} editMode={this.state.editMode} propertyType={this.props.propertyType} propertyValue={this.props.propertyValue.value} onSubmit={this.handleSubmit} />
            : <InheritedPropertyValueComponent ref={this.captureValueElement} editMode={this.state.editMode} propertyType={this.props.propertyType} propertyValueKey={this.props.propertyValue.key} onSubmit={this.handleSubmit} />;

        return (
            <div className={divClass} onClick={this.handleEdit}>
                <div className="chrome">
                    <PropertyName name={this.props.propertyName}  />
                    <PropertyValueTypeComponent currentValue={this.state.propertyValueType} editMode={this.state.editMode} onChange={this.handlePropertyValueTypeChange} />
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

    captureValueElement: function(c) {
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
            this.setState({ editMode: false });
        }
    },

    handlePropertyValueTypeChange: function (propertyValueType) {
        if (this.state.propertyValueType !== propertyValueType) {
            this.setState({ propertyValueType: propertyValueType });
        }
    }
});

module.exports = PropertyComponent;


