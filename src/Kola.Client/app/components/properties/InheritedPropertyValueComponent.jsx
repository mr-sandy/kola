var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    render: function () {
        return this.props.editMode
            ? (
            <div className="value">
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.key} onChange={this.handleChange} onBlur={this.handleBlur} ref={this.captureInput} />
                </form>
            </div>)
            : (
            <div className="value">
                <span>{this.state.key}</span>
            </div>);
    },

    captureInput: function (input) {
        $(input).focus().select();
    },

    getInitialState: function () {
        return { key: this.props.propertyValue.key ? this.props.propertyValue.key : this.props.propertyName };
    },

    handleChange: function (e) {
        this.setState({ key: e.target.value });
    },

    handleBlur: function () {
        if (this.props.propertyValue.key !== this.state.key) {
            this.props.onSubmit();
        }
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.props.onSubmit();
    },

    value: function () {
        return {
            type: 'inherited',
            key: this.state.key
        };
    }
});

