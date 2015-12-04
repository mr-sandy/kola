var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {

        return this.props.editMode
            ? 
            <div className="value">
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.key} onChange={this.handleChange} onBlur={this.handleBlur} onClick={this.handleClick} ref={this.captureInput} />
                </form>
            </div>
            : 
            <div className="value">
                <span>{this.state.key}</span>
            </div>;
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

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
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

