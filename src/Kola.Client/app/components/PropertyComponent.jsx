var PropertyValueTypeComponent = require('app/components/PropertyValueTypeComponent.jsx');
var FixedPropertyValueComponent = require('app/components/FixedPropertyValueComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

var PropertyName = (props) => {
    return <label className="name">{props.name}</label>;
}

var PropertyComponent = React.createClass({

    render: function () {
        return (
            <div className="property">
                <div className="chrome">
                    <PropertyName name={this.props.propertyName} />
                    <PropertyValueTypeComponent currentValue={this.props.propertyValue.type} />
                </div>
                <FixedPropertyValueComponent propertyType={this.props.propertyType} propertyValue={this.props.propertyValue.value} />
            </div>
            );
    }
});

module.exports = PropertyComponent;
