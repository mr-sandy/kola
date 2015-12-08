var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {

        return this.props.editMode
            ? this.renderEditMode()
            : this.renderReadOnlyMode();
    },

    renderEditMode: function () {
        const propertyValueType = this.props.propertyValue ? this.props.propertyValue.type : '';

        return (
            <div className="chrome clearfix">
                    <span className="name">{this.props.propertyName}</span>
                    <select className="propertyValueType" value={propertyValueType} onClick={this.handleClick} onChange={this.handleChange}>
                        <option value=""></option>
                        <option value="fixed">fixed</option>
                        <option value="inherited">inherited</option>
                    </select>
            </div>
        );
    },

    renderReadOnlyMode: function () {
        const propertyValueType = this.props.propertyValue ? this.props.propertyValue.type : 'unset';

        return (
                <div className="chrome clearfix">
                    <span className="name">{this.props.propertyName}</span>
                    <span className="propertyValueType">{propertyValueType}</span>
                </div>
            );
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    },

    handleClick: function (e) {
        e.stopPropagation();
    }
});



