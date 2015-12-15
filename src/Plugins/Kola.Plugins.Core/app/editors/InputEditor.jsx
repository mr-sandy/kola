var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        type: React.PropTypes.string.isRequired,
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <form onSubmit={this.handleSubmit}><input type={this.props.type} ref={this.highlightText} value={this.state.value} onChange={this.handleChange} onBlur={this.handleBlur} /></form>
            : <span>{this.props.value}</span>;
    },

    getInitialState: function () {
        return { value: this.props.value };
    },

    componentWillReceiveProps: function (nextProps) {
        this.setState({value: nextProps.value});
    },

    highlightText: function (element) {
        $(element).focus().select();
    },

    handleChange: function (e) {
        var value = this.props.sanitize
            ? this.props.sanitize(e.target.value)
            : e.target.value;
        this.setState({ value: value });
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
