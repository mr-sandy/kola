var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onChange: React.PropTypes.func.isRequired,
        onBlur: React.PropTypes.func.isRequired,
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {

        return this.props.editMode
            ?
            <div className="value">
                <form onSubmit={this.handleSubmit}>
                    <input type="text" value={this.props.propertyValue.key} onChange={this.handleChange} onBlur={this.props.onBlur} onClick={this.handleClick} ref={this.setFocus} />
                </form>
            </div>
            :
            <div className="value">
                <span>{this.props.propertyValue.key}</span>
            </div>;
    },

    setFocus: function (el) {
        $(el).focus().select();
    },

    handleChange: function (e) {
        this.props.onChange({
            type: 'inherited',
            key: e.target.value
        });
    },

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
        }
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.props.onSubmit();
    }
});

//getInitialState: function () {
//    return {
//        propertyValue: {
//            type: "inherited",
//            key: this.props.propertyValue.key ? this.props.propertyValue.key : this.props.propertyName
//        }
//    };
//},
