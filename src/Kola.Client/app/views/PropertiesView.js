var Backbone = require('backbone');
var $ = require('jquery');
var _ = require('underscore');
var stateBroker = require('app/views/StateBroker');
var PropertyView = require('app/views/PropertyView');
var template = require('app/templates/PropertiesTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        _.bindAll(this, 'render');
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

    render: function () {
        var self = this;

        if (this.model) {
            this.$el.html(this.template(this.model.toJSON()));

            var $content = this.$el.find('.content').first();
            var componentPath = this.model.get('path');

            _.each(this.model.get('properties'), function (property) {
                var propertyView = new PropertyView({
                    model: property,
                    amendments: self.amendments,
                    componentPath: componentPath
                });

                $content.append(propertyView.render().$el);
            });
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