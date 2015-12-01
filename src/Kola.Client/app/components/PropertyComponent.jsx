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
            <div>
                <PropertyName name={this.props.name} />
                <PropertyValueTypeComponent currentValue={this.props.value.type} />
                <FixedPropertyValueComponent propertyType={this.props.type} propertyValue={this.props.value.value} />
            </div>);
    }
});

module.exports = PropertyComponent;
