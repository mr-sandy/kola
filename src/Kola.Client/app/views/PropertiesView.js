var Backbone = require('backbone');
var $ = require('jquery');
var _ = require('underscore');
var stateBroker = require('app/views/StateBroker');
var PropertiesComponent = require('app/components/properties/PropertiesComponent.jsx');
var template = require('app/templates/PropertiesTemplate.hbs');
var footerTemplate = require('app/templates/PropertiesButtonsTemplate.hbs');
var React = require('react');
var ReactDOM = require('react-dom');

var PropertiesView = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        _.bindAll(this, 'render', 'handlePropertyChange');
        this.amendments = options.amendments;
        this.filterUnset = false;

        this.uiStateDispatcher = options.uiStateDispatcher;
        this.uiStateDispatcher.on('toggle-properties', this.toggleHidden, this);

        stateBroker.on('selected', this.handleSelected, this);
        stateBroker.on('deselected', this.handleDeselected, this);
    },

    events: {
        'click #remove': 'remove',
        'click #duplicate': 'duplicate',
        'click #toggle-filter-unset': 'toggleUnset'
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
        const path = this.model.get('path');

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
        return !this.rendered ? this.initialRender() : this.updateRender();
    },

    initialRender: function () {

        this.rendered = true;

        this.$el.html(template());

        const $content = this.$el.find('.content').first();

        const props = {
            properties: this.model ? this.model.get('properties') : [],
            filterUnset: this.filterUnset,
            onChange: this.handlePropertyChange
        };

        this.reactComponent = ReactDOM.render(React.createElement(PropertiesComponent, props), $content[0]);

        this.$footer = this.$el.find('.footer').first();
        this.renderFooter();

        return this;
    },

    updateRender: function () {

        const props = {
            properties: this.model ? this.model.get('properties') : [],
            filterUnset: this.filterUnset,
            onChange: this.handlePropertyChange
        };

        this.reactComponent.replaceProps(props);
        this.renderFooter();

        return this;
    },

    renderFooter: function() {
        this.$footer.html(footerTemplate({
            disabled: this.model ? false : true,
            filterUnset: this.filterUnset
        }));
    },

    remove: function (e) {
        const componentPath = this.model.get('path');
        this.amendments.removeComponent(componentPath);
    },

    duplicate: function (e) {
        const componentPath = this.model.get('path');
        this.amendments.duplicateComponent(componentPath);
    },

    toggleUnset: function () {
        this.filterUnset = !this.filterUnset;
        this.render();
    },

    toggleHidden: function () {
        this.$el.toggleClass('hidden');
    }
});

module.exports = PropertiesView;
