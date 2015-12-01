var _ = require('underscore');
var $ = require('jquery');
var React = require('react');
var ReactDOM = require('react-dom');

var FixedPropertyValueComponent = React.createClass({

    render: function () {

        var propertyType = this.props.propertyType;
        var plugin = _.find(kola.propertyEditors, function (ed) {
            return ed.propertyType === propertyType;
        });

        //if (plugin) {
        //    this.$el.html(this.template(this.model));
        //    var $editorElement = this.$el.find('.value').last();

        //    plugin.render($editorElement, this.model.value.value);
        //}

        //var editor = kola.propertyEditors[]

        var propertyValue = this.props.propertyValue;

        var doIt = function (el) {
            if (el != null) {
                plugin.render($(el), propertyValue);
            }
        };

        var divClass = 'value ' + this.props.propertyType;

        return (
            <div className={divClass} ref={doIt}></div>
            );
    }
});

module.exports = FixedPropertyValueComponent;
