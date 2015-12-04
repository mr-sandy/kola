var PropertyValueTypeComponent = require('app/components/properties/PropertyValueTypeComponent.jsx');
var _ = require('underscore');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onPropertyValueTypeChange: React.PropTypes.func.isRequired
    },


    render: function () {
        const childProps = _.pick(this.props, 'editMode', 'propertyValue', 'onPropertyValueTypeChange');

        return (
                <div className="chrome clearfix">
                    <span className="name">{this.props.propertyName}</span>
                    <PropertyValueTypeComponent {...childProps} />
                </div>
            );
    }
});



