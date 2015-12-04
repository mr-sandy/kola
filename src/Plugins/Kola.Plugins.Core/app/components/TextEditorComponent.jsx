var React = require('react');

var TextEditorComponent = React.createClass({

    render: function () {
        return this.props.editMode
            ? <form onSubmit={this.handleSubmit}><input type="text" value={this.state.value} onChange={this.handleChange} onBlur={this.handleBlur} /></form>
            : <span>{this.state.value}</span>;
    },

    getInitialState: function () {
        return { value: this.props.value };
    },

    handleChange: function(e){
        this.setState({ value: e.target.value });
    },

    handleBlur: function () {
        if (this.props.value != this.state.value) {
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

module.exports = TextEditorComponent;
