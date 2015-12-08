var Backbone = require('backbone');
var $ = require('jquery');
var _ = require('underscore');
var stateBroker = require('app/views/StateBroker');
var PropertiesComponent = require('app/components/properties/PropertiesComponent.jsx');
var template = require('app/templates/PropertiesTemplate.hbs');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        _.bindAll(this, 'render', 'handlePropertyChange');
        this.amendments = options.amendments;

        this.uiStateDispatcher = options.uiStateDispatcher;
        this.uiStateDispatcher.on('toggle-properties', this.toggleHidden, this);

        stateBroker.on('selected', this.handleSelected, this);
        stateBroker.on('deselected', this.handleDeselected, this);
    },

    events: {
        'click #remove': 'remove',
        'click #duplicate': 'duplicate'
    },

    handleSelected: function (model) {
        this.model = model;

        if (this.model !== null) {
            this.listenTo(model, 'sync', this.render);
        }

        this.render();
    },

    handleDeselected: function (model) {
        this.model = null;

        this.stopListening(model);

        this.render();
    },

    handlePropertyChange: function (data) {
        var path = this.model.get('path');

        if (data.propertyValue === null) {
            this.amendments.resetProperty(path, data.propertyName);
        } else {
            switch (data.propertyValue.type) {
                case 'fixed':
                    this.amendments.setPropertyFixed(path, data.propertyName, data.propertyValue.value);
                    break;
                case 'inherited':
                    this.amendments.setPropertyInherited(path, data.propertyName, data.propertyValue.key);
                    break;
            }
        }
    },

    render: function () {
        if (this.model) {
            this.$el.html(this.template(this.model.toJSON()));

            var $content = this.$el.find('.content').first();

            var model = {
                properties: this.model.get('properties'),
                onChange: this.handlePropertyChange
            };

            ReactDOM.render(React.createElement(PropertiesComponent, model), $content[0]);
        }
        else {
            this.$el.html(this.template({ 'disabled': true }));
        }

        return this;
    },

    remove: function (e) {
        e.preventDefault();
        var componentPath = this.model.get('path');
        this.amendments.removeComponent(componentPath);
        //this.stateBroker.deselect();
    },

    duplicate: function (e) {
        e.preventDefault();
        var componentPath = this.model.get('path');
        this.amendments.duplicateComponent(componentPath);
    },

    toggleHidden: function () {
        this.$el.toggleClass('hidden');
    }
});