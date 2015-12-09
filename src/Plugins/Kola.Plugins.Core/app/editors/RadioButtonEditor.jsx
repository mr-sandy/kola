var React = require('react');

module.exports = React.createClass({

    propTypes: {
        options: React.PropTypes.array.isRequired,
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired
    },

    render: function () {
        var currentValue = this.props.value;
        var handleChange = this.handleChange;

        const buttons = this.props.options.map(function (o) {
            const checked = o === currentValue;
            return <label key={o} className="radio-button" htmlFor={o}><input id={o} type="radio" name="options" checked={checked} value={o} onChange={handleChange} />{o}</label>;
        });

        return this.props.editMode
            ? <form>
                {buttons}
            </form>
            : <span>{this.props.value}</span>;
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    }
});
