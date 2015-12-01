var PropertyComponent = require('app/components/PropertyComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

var PropertiesComponent = React.createClass({

    renderProperty: function (property) {
        return <PropertyComponent key={property.name} propertyName={property.name} propertyType={property.type} propertyValue={property.value} />;
    },

    render: function () {
        return (
            <div>
                {this.props.properties.map(this.renderProperty)}
            </div>);
    }
});

module.exports = PropertiesComponent;
