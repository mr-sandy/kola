var _ = require('underscore');
var React = require('react');
var ReactDOM = require('react-dom');

var FixedPropertyValueComponent = React.createClass({

    render: function () {


        //if (plugin) {
        //    this.$el.html(this.template(this.model));
        //    var $editorElement = this.$el.find('.value').last();

        //    plugin.render($editorElement, this.model.value.value);
        //}

        //var editor = kola.propertyEditors[]

        //var doIt = function (el) {
        //    if (el != null) {
        //        plugin.render($(el), propertyValue);
        //    }
        //};

        var divClass = 'value ' + this.props.propertyType;

        return (
            <div className={divClass} ref={this.renderFromPlugin}></div>
            );
    },

    renderFromPlugin(el) {
        if (el != null) {
            var propertyType = this.props.propertyType;
            var propertyValue = this.props.propertyValue;

            var editor = _.find(kola.propertyEditors, function (ed) {
                return ed.propertyType === propertyType;
            });

            editor.render(el, propertyValue);
        }
    }
});

module.exports = FixedPropertyValueComponent;
