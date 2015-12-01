var Backbone = require('backbone');
var _ = require('underscore');
var PropertyComponent = require('app/components/PropertyComponent.jsx');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = Backbone.View.extend({

    tagName: 'div',

    className: 'property',

    initialize: function (options) {
        this.editMode = false;
        this.amendments = options.amendments;
        this.componentPath = options.componentPath;
    },

    render: function () {
        //handleSelect: this.clickHandler.bind(this)

        var model = _.extend({}, this.model, {});
        ReactDOM.render(React.createElement(PropertyComponent, model), this.$el[0]);

        return this;
    }
});