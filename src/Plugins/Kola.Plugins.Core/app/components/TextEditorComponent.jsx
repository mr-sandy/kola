var React = require('react');

var TextEditorComponent = React.createClass({

    render: function () {
        return this.props.editMode
            ? <form><input type="text" value={this.state.value} onChange={this.handleChange} /></form>
            : <span>{this.state.value}</span>;
    },

    getInitialState: function () {
        return { value: this.props.value };
    },

    handleChange: function(e){
        this.setState({ value: e.target.value });
    },

    value: function () {
        return this.state.value;
    }
});

module.exports = TextEditorComponent;
