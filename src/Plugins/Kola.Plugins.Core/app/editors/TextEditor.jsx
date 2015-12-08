var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <form onSubmit={this.handleSubmit}><input type="text" ref={this.highlightText} value={this.state.value} onChange={this.handleChange} onBlur={this.handleBlur} /></form>
            : <span>{this.props.value}</span>;
    },

    getInitialState: function () {
        return { value: this.props.value };
    },

    highlightText: function (element) {
        $(element).focus().select();
    },

    handleChange: function (e) {
        this.setState({ value: e.target.value });
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.doChange();
    },

    handleBlur: function () {
        if (this.props.value !== this.state.value)
        {
            this.doChange();
        }
    },

    doChange: function(){
        this.props.onChange(this.state.value ? this.state.value : '');
    }
});
