var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

var FixedPropertyValueComponent = React.createClass({

    render: function () {
        return <div className={`value ${this.props.propertyType}`} ref={this.captureElement}></div>;
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

    captureElement(el) {
        this._element = el;
    },

    value: function () {
        return {
            type: 'fixed',
            value: this.editor.value()
        };
    },

    renderFromPlugin() {
        if (this._element != null) {
            var propertyType = this.props.propertyType;

            this.editor = _.find(kola.propertyEditors, function (ed) {
                return ed.propertyType === propertyType;
            });

            this.editor.render(this._element, this.props.propertyValue.value, this.props.editMode, this.props.onSubmit, this.props.onFastEdit);

            $(this._element).find('input').first().focus().select();
        }
    }
});

module.exports = FixedPropertyValueComponent;
