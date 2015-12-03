var _ = require('underscore');
var $ = require('jquery');
var React = require('react');

var FixedPropertyValueComponent = React.createClass({

    render: function () {
        var divClass = 'value ' + this.props.propertyType;

        return <div className={divClass} ref={this.captureElement}></div>;
    },

    shouldComponentUpdate: function (nextProps, nextState) {
        return true;
    },

    componentDidUpdate: function (prevProps, prevState) {
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

            this.editor.render(this._element, this.props.propertyValue.value, this.props.editMode);

            var onSubmit = this.props.onSubmit;

            $(this._element).find('form').children().first().focus().select();
            $(this._element).find('form').submit(function (e) {
                e.preventDefault();
                onSubmit();
            });

        }
    }
});

module.exports = FixedPropertyValueComponent;
