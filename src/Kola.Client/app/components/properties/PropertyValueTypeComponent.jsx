var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <select className="propertyValueType" value={this.props.propertyValue.type} onClick={this.handleClick} onChange={this.handleChange}>
                <option value="fixed">fixed</option>
                <option value="inherited">inherited</option>
            </select>
            : <span className="propertyValueType">{this.props.propertyValue.type}</span>;
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    },
    
    handleClick: function (e) {
        e.stopPropagation();
    }
});
