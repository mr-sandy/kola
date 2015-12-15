var PropertyComponent = require('app/components/properties/PropertyComponent.jsx');
var React = require('react');

var PropertiesComponent = React.createClass({

    propTypes: {
        onChange: React.PropTypes.func.isRequired,
        properties: React.PropTypes.array
    },

    render: function () {
        var onChange = this.props.onChange;

        const properties = this.props.properties ? this.props.properties : [];

        const propertyComponents = properties.map(function (property) {
            return <PropertyComponent key={property.name} propertyName={property.name} propertyType={property.type} propertyValue={property.value} onChange={onChange} />;
        });

        return (
            <div>
                {propertyComponents}
            </div>);
    }
});

module.exports = PropertiesComponent;
