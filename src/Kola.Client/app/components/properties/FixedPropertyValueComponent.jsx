var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

module.exports = React.createClass({

    propTypes: {
        editMode: React.PropTypes.bool.isRequired,
        propertyType: React.PropTypes.string.isRequired,
        propertyValue: React.PropTypes.object.isRequired,
        onSubmit: React.PropTypes.func.isRequired
    },

    render: function () {
        return <div className={`value ${this.props.propertyType}`} ref={this.captureElement} onClick={this.handleClick}></div>;
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

    handleSubmit: function () {
        this.props.onSubmit();
    },

    value: function(){
        return {
            type: 'fixed',
            value: this.editor.value()
        };
    },

    handleClick: function (e) {
        if (this.props.editMode) {
            e.stopPropagation();
        }
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
