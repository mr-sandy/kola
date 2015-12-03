var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

var InheritedPropertyValueComponent = React.createClass({

    render: function () {
        return this.props.editMode
            ? <div className="value"><form ref={this.captureForm}><input type="text" value={this.state.key} onChange={this.handleChange} /></form></div>
            : <div className="value"><span>{this.state.key}</span></div>;
    },

    captureForm(form) {
        var onSubmit = this.props.onSubmit;

        $(form).children().first().focus().select();
        $(form).submit(function (e) {
            e.preventDefault();
            onSubmit();
        });
    },

    getInitialState: function () {
        return { key: this.props.propertyValue.key };
    },

    handleChange: function(e){
        this.setState({ key: e.target.value });
    },

    value: function () {
        return {
            type: 'inherited',
            key: this.state.key
        };
    }
});

module.exports = InheritedPropertyValueComponent;
