var PropertyComponent = require('app/components/properties/PropertyComponent.jsx');
var React = require('react');
var classNames = require('classNames');

var PropertiesComponent = React.createClass({

    propTypes: {
        onChange: React.PropTypes.func.isRequired,
        filterUnset: React.PropTypes.bool.isRequired,
        properties: React.PropTypes.array
    },

    render: function () {
        var onChange = this.props.onChange;

        const propertyComponents = this.props.properties.map(function (property) {
            return <PropertyComponent key={property.name} propertyName={property.name} propertyType={property.type} propertyValue={property.value} onChange={onChange} />;
        });

        var className = classNames({ 'filter-unset': this.props.filterUnset });

        return (
            <div className={className}>
                {propertyComponents}
            </div>);
    }
});

module.exports = PropertiesComponent;
