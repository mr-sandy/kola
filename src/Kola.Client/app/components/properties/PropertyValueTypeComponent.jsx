var React = require('react');

var PropertyValueTypeComponent = React.createClass({
    propertyValueTypes: ['fixed', 'inherited'],

    render: function () {
        if (this.props.editMode) {
            var options = this.propertyValueTypes.map(function (valueType) {
                return <option key={valueType} value={valueType}>{valueType}</option>;
            });

            return <select className="propertyValueType" onChange={this.handleChange} value={this.props.currentValue}>{options}</select>;
        }
        else {
            return <span className="propertyValueType">{this.props.currentValue}</span>;
        }
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    }
});

module.exports = PropertyValueTypeComponent;
