var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {

        return this.props.editMode
            ? <div className="value">
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.state.key} onChange={this.handleChange} onBlur={this.handleBlur} onClick={this.handleClick} ref={this.setFocus} />
                </form>
            </div>
            : <div className="value">
                <span>{this.props.propertyValue.key}</span>
            </div>;
    },

    getInitialState: function () {
        return { key: this.props.propertyValue.key };
    },

    setFocus: function (el) {
        $(el).focus().select();
    },

    handleChange: function (e) {
        this.setState({ key: e.target.value });
    },


    handleSubmit: function (e) {
        e.preventDefault();
        this.handleBlur();
    },

    handleBlur: function () {
//        if (this.props.propertyValue.key !== this.state.key) {
            this.props.onChange({
                type: 'inherited',
                key: this.state.key
            });
//        }
    },

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
        }
    }
});
