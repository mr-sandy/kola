var FixedPropertyValueComponent = require('app/components/properties/FixedPropertyValueComponent.jsx');
var InheritedPropertyValueComponent = require('app/components/properties/InheritedPropertyValueComponent.jsx');
var React = require('react');

function Unset(props) {
    const divClasses = 'value unnsett ' + props.propertyType;
    return <div className={divClasses}></div>;
}

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired
    },



    render: function () {
        const propertyValueType = this.props.propertyValue ? this.props.propertyValue.type : '';

        switch (propertyValueType) {
            case 'inherited':
                return <InheritedPropertyValueComponent {...this.props} />;

            case 'fixed':
                return <FixedPropertyValueComponent {...this.props} />;

            default:
                return <Unset />;
        };
    }
});
