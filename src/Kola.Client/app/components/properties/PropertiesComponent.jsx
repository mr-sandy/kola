var PropertyComponent = require('app/components/properties/PropertyComponent.jsx');
var _ = require('underscore');
var React = require('react');

var PropertiesComponent = React.createClass({

    propTypes: {
        onChange: React.PropTypes.func.isRequired,
        properties: React.PropTypes.array
    },

    render: function () {
        var onChange = _.once(this.props.onChange);

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
