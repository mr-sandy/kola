var React = require('react');

var MarkdownEditorComponent = React.createClass({

    render: function () {
        return this.props.editMode
            ? this.renderEditMode()
            : <span>{this.state.value}</span>;
    },

    renderEditMode: function () {
        var modalClass = this.state.expanded ? 'modal shown' : 'modal';

        return (
        <form>
            <span onClick={this.handleOpen}>{this.state.value}</span>
            <div className={modalClass}>
                <div className="chrome">
                    <span>Markdown</span>
                </div>
                <div className="content">
                    <textarea rows="20" value={this.state.value} onChange={this.handleChange}></textarea>
                </div>
                <div className="controls">
                    <button type="button" className="cancel" value="cancel" onClick={this.handleClose}>Cancel</button>
                    <button type="button" value="Ok" onClick={this.handleClose}>Ok</button>
                </div>
            </div>
        </form>);
    },

    getInitialState: function () {
        return {
            value: this.props.value,
            expanded: false
        };
    },

    handleChange: function (e) {
        this.setState({ value: e.target.value });
    },

    handleOpen: function () {
        this.setState({ expanded: true });
    },

    handleClose: function () {
        this.setState({ expanded: false });
    },

    value: function () {
        return this.state.value;
    }
});

module.exports = MarkdownEditorComponent;
