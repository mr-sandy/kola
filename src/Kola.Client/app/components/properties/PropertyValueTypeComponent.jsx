var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onPropertyValueTypeChange: React.PropTypes.func.isRequired
    },

    render: function () {
        if (this.props.editMode) {
            return (
            <select className="propertyValueType" value={this.props.propertyValue.type} onChange={this.handleChange}>
                <option value="fixed">fixed</option>
                <option value="inherited">inherited</option>
            </select>);
        }
        else {
            return <span className="propertyValueType">{this.props.propertyValue.type}</span>;
        }
    },

    handleChange: function (e) {
        this.props.onPropertyValueTypeChange(e.target.value);
    }
});
