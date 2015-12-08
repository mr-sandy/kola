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
            ? <form>
                <select value={this.props.value} onChange={this.handleChange} >
                    <option value=""></option>
                    <option value="text/css">text/css</option>
                </select>
              </form>
            : <span>{this.props.value}</span>;
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    }
});
