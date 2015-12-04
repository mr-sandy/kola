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
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {
        const childProps = _.omit(this.props, 'onEditModeChange');

        return this.props.propertyValue.type === 'fixed'
            ? <FixedPropertyValueComponent {...childProps} ref={this.captureComponent} />
            : <InheritedPropertyValueComponent {...childProps} ref={this.captureComponent} />;
    },

    captureComponent: function(c)
    {
        this.component = c;
    },

    value: function () {
        return this.component.value();
    }

});



