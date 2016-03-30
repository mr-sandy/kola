var _ = require('underscore');
var $ = require('jquery');
var React = require('react');
var PropertyVariantComponent = require('app/components/properties/PropertyVariantComponent.jsx');

var VariablePropertyValueComponent = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object
    },

    render: function () {

        const { propertyName, propertyType, propertyValue } = this.props;

        const children = propertyValue.variants.map(v => <PropertyVariantComponent key={v.contextValue } {...v} propertyName={propertyName} propertyType={propertyType} />);

        return (
                <div className="value">
                    <span>{this.props.propertyValue.contextName}</span>
                    {children}
                </div>
            );
    }
});

module.exports = VariablePropertyValueComponent;