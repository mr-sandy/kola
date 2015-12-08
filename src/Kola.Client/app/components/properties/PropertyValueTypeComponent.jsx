var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyValue: React.PropTypes.object,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        const propertyValueType = this.props.propertyValue ? this.props.propertyValue.type : 'unset';

        return this.props.editMode
            ? <select className="propertyValueType" value={propertyValueType} onClick={this.handleClick} onChange={this.handleChange}>
                <option value=""></option>
                <option value="fixed">fixed</option>
                <option value="inherited">inherited</option>
            </select>
            : <span className="propertyValueType">{propertyValueType}</span>;
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    },
    
    handleClick: function (e) {
        e.stopPropagation();
    }
});
