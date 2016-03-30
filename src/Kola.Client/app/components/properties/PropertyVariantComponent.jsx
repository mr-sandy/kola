var _ = require('underscore');
var $ = require('jquery');
var PropertyValueComponent = require('app/components/properties/PropertyValueComponent.jsx');
var FixedPropertyValueComponent = require('app/components/properties/FixedPropertyValueComponent.jsx');
var InheritedPropertyValueComponent = require('app/components/properties/InheritedPropertyValueComponent.jsx');
//var VariablePropertyValueComponent = require('app/components/properties/VariablePropertyValueComponent.jsx');
var React = require('react');

var PropertyVariant = React.createClass({
    render: function () {
        const { contextValue, propertyName, propertyType, value } = this.props;

        const childProps = {
            editMode: false,
            propertyName: propertyName,
            propertyType: propertyType,
            propertyValue: value,
            onChange: e => {},
            onCancel: e => {}
        };
        
        return (
            <div className="property-variant">
                <div className="clearfix">
                    <span className="name">{contextValue}</span>
                    <span className="propertyValueType">{value.type}</span>
                </div>
                {this.renderValue(value.type, childProps)}
            </div>
        );
    },

    renderValue: function(propertyValueType, props) {
        switch (propertyValueType) {
            case 'fixed':
                return <FixedPropertyValueComponent {...props} />;

            case 'inherited':
                return <InheritedPropertyValueComponent {...props} />;

            //case 'variable':
            //    return <VariablePropertyValueComponent {...props} />;

            default:
                return false;
        };
    }
})

module.exports = PropertyVariant;

