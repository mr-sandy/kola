var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        value: React.PropTypes.string,
        onChange: React.PropTypes.func.isRequired,
        onSubmit: React.PropTypes.func.isRequired,
        onBlur: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? this.renderEditMode()
            : <span>{this.props.value}</span>;
    },

    renderEditMode: function () {
        var modalClass = this.state.expanded ? 'modal shown' : 'modal';

        return (
        <form>
            <span onClick={this.handleOpen}>{this.props.value}</span>
            <div className={modalClass}>
                <div className="chrome">
                    <span>Markdown</span>
                </div>
                <div className="content">
                    <textarea rows="20" value={this.props.value} onChange={this.handleChange}></textarea>
                </div>
                <div className="controls">
                    <button type="button" className="cancel" value="cancel" onClick={this.handleClose}>Cancel</button>
                    <button type="button" value="Ok" onClick={this.handleSubmit}>Ok</button>
                </div>
            </div>
        </form>);
    },

    getInitialState: function () {
        return { expanded: true };
    },

    handleOpen: function () {
        this.setState({ expanded: true });
    },

    handleClose: function () {
        this.setState({ expanded: false });
    },

    handleChange: function (e) {
        this.props.onChange(e.target.value);
    },

    handleSubmit: function (e) {
        e.preventDefault();
        this.props.onSubmit();
    }
});
