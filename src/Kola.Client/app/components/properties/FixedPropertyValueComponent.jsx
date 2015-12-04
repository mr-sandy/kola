var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        //propertyName: React.PropTypes.string.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onSubmit: React.PropTypes.func.isRequired,
        onEditModeChange: React.PropTypes.func.isRequired
    },

    render: function () {
        return this.props.editMode
            ? <div className={`value ${this.props.propertyType}`} ref={this.captureElement}></div>
            : <div className={`value ${this.props.propertyType}`} ref={this.captureElement} onClick={this.handleEditModeChange}></div>;
    },

    captureElement(el) {
        this._element = el;
    },

    shouldComponentUpdate: function () {
        return true;
    },

    componentDidUpdate: function () {
        this.renderFromPlugin();
    },

    componentDidMount: function () {
        this.renderFromPlugin();
    },

    handleEditModeChange: function () {
        this.props.onEditModeChange(true);
    },

    handleSubmit: function () {
        this.props.onSubmit({
            type: 'fixed',
            value: this.editor.value()
        });
    },

    renderFromPlugin() {
        var propertyType = this.props.propertyType;

        this.editor = _.find(kola.propertyEditors, function (ed) {
            return ed.propertyType === propertyType;
        });

        this.editor.render(this._element, this.props.propertyValue.value, this.props.editMode, this.handleSubmit);

        $(this._element).find('input').first().focus().select();
    }
});
