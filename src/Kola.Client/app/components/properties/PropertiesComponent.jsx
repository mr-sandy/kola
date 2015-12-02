var PropertyComponent = require('app/components/properties/PropertyComponent.jsx');
var React = require('react');

var PropertiesComponent = React.createClass({

    render: function () {
        var onChange = this.props.onChange;

        var properties = this.props.properties.map(function (property) {
            return <PropertyComponent key={property.name} propertyName={property.name} propertyType={property.type} propertyValue={property.value} onChange={onChange} />;
        });

        return (
            <div>
                {properties}
            </div>);
    }
});

module.exports = PropertiesComponent;
