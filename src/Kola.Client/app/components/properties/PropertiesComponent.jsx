var PropertyComponent = require('app/components/properties/PropertyComponent.jsx');
var React = require('react');

var PropertiesComponent = React.createClass({

    render: function () {
        var handleChange = this.props.handleChange;

        var properties = this.props.properties.map(function (property) {
            return <PropertyComponent key={property.name} propertyName={property.name} propertyType={property.type} propertyValue={property.value} handleChange={handleChange} />;
        });

        return (
            <div>
                {properties}
            </div>);
    }
});

module.exports = PropertiesComponent;
