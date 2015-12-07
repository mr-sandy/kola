var FixedPropertyValueComponent = require('app/components/properties/FixedPropertyValueComponent.jsx');
var InheritedPropertyValueComponent = require('app/components/properties/InheritedPropertyValueComponent.jsx');
var _ = require('underscore');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired,
        onBlur: React.PropTypes.func.isRequired,
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.propertyValue.type === 'fixed'
            ? <FixedPropertyValueComponent {...this.props} />
            : <InheritedPropertyValueComponent {...this.props} />;
    }
});



