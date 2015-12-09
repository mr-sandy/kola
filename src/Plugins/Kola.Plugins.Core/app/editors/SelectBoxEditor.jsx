var React = require('react');

module.exports = React.createClass({

    propTypes: {
        options: React.PropTypes.array.isRequired,
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        const options = this.props.options.map(o => <option key={o} value={o}>{o}</option>);

        return this.props.editMode
            ? <form>
                <select value={this.props.value} onChange={this.handleChange} >
                    {options}
                </select>
              </form>
            : <span>{this.props.value}</span>;
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    }
});
