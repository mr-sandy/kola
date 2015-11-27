var Backbone = require('backbone');
var _ = require('underscore');
var template = require('app/templates/PropertyTemplate.hbs');
var PropertyValueTypeView = require('app/views/PropertyValueTypeView');
var PropertyValueTypeComponent = require('app/components/PropertyValueTypeComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = Backbone.View.extend({

    template: template,

    tagName: 'div',

    className: 'property',

    initialize: function (options) {
        this.editMode = false;
        this.amendments = options.amendments;
        this.componentPath = options.componentPath;

        this.propertyValueTypeView = new PropertyValueTypeView({
            model: this.model.value.type
        });
    },

    clickHandler: function () {
        alert('click!');
    },

    render: function () {
        this.$el.html(this.template(this.model));

        ReactDOM.render(React.createElement(PropertyValueTypeComponent, {
            handleClick: this.clickHandler.bind(this)
        }), this.$('.valueType')[0]);

        if (this.model.value) {
            switch (this.model.value.type) {
                case 'fixed':
                    this.renderFixed();
                    break;
                case 'inherited':
                    this.renderInherited();
                    break;
                default:
            }
        }
        //var propertyType = this.model.type;
        //var plugin = _.find(kola.propertyEditors, function (ed) {
        //    return ed.propertyType === propertyType;
        //});

        //if (plugin) {
        //    this.$el.html(this.template(this.model));
        //    var $editorElement = this.$el.find('.value').last();

        //    plugin.render($editorElement, this.model.value.value);
        //}

        return this;
    },

    renderFixed: function () { },

    renderInherited: function () { }

});