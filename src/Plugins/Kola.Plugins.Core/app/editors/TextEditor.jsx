var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onSubmit: React.PropTypes.func.isRequired
        //propertyType: React.PropTypes.string.isRequired,
        //propertyValue: React.PropTypes.object.isRequired,
        //onEditModeChange: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <form onSubmit={this.handleSubmit}><input type="text" value={this.state.value} onChange={this.handleChange} onBlur={this.handleBlur} /></form>
            : <span>{this.state.value}</span>;
    },

    getInitialState: function () {
        return { value: this.props.value };
    },

    handleChange: function (e) {
        this.setState({ value: e.target.value });
    },

    handleBlur: function () {
        if (this.props.value !== this.state.value) {
            this.props.onSubmit();
        }
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.props.onSubmit();
    },

    value: function () {
        return this.state.value;
    }
});
