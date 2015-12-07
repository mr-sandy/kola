var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired,
        onSubmit: React.PropTypes.func.isRequired,
        onBlur: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <form onSubmit={this.handleSubmit}><input ref={this.highlightText} type="text" value={this.props.value} onChange={this.handleChange} onBlur={this.props.onBlur} /></form>
            : <span>{this.props.value}</span>;
    },

    highlightText: function(el){
        $(el).focus().select();
    },

    handleChange: function(e){
        this.props.onChange(e.target.value);
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.props.onSubmit();
    }
});
