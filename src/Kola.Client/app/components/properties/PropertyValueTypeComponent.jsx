var React = require('react');

var PropertyValueTypeComponent = React.createClass({
    propertyValueTypes: ['fixed', 'inherited'],

    render: function () {
        return (this.props.editMode)
            ? this.renderEdit()
            : <span className="propertyValueType">{this.props.currentValue}</span>;
    },

    renderEdit: function () {
        var options = this.propertyValueTypes.map(function (valueType) {
            return <option key={valueType} value={valueType}>{valueType}</option>;
        });

        return (
        <select className="propertyValueType" onChange={this.handleChange} value={this.props.currentValue}>
            {options}
        </select>);
    },

    handleChange: function () {

    }
});

module.exports = PropertyValueTypeComponent;
