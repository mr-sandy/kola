var _ = require('underscore');
var React = require('react');
var ReactDOM = require('react-dom');

var FixedPropertyValueComponent = React.createClass({

    render: function () {
        var divClass = 'value ' + this.props.propertyType;

        return (
            <div className={divClass} ref={(c) => {this._input = c; this.renderFromPlugin();}}></div>
            );
    },

    shouldComponentUpdate: function(nextProps, nextState) {
        return true;
    },

    componentDidUpdate: function(prevProps, prevState){
        this.renderFromPlugin(null);
    },

    value: function () {
        return this.editor.value();
    },

    renderFromPlugin(el) {
        if (this._input != null) {
            var propertyType = this.props.propertyType;
            var propertyValue = this.props.propertyValue;

            this.editor = _.find(kola.propertyEditors, function (ed) {
                return ed.propertyType === propertyType;
            });

            this.editor.render(this._input, propertyValue, this.props.editMode);
        }
    }
});

module.exports = FixedPropertyValueComponent;
