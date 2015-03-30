define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var Template = require('text!app/templates/SidebarTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.uiStateDispatcher = options.uiStateDispatcher;
            this.uiStateDispatcher.on('toggle-tools', function() { this.$el.toggleClass('hidden'); }, this);
            this.uiStateDispatcher.on('toggle-toolbox', function() { this.$('.toggle-toolbox').toggleClass('selected'); }, this);
            this.uiStateDispatcher.on('toggle-block-editor', function() { this.$('.toggle-block-editor').toggleClass('selected'); }, this);
            this.uiStateDispatcher.on('toggle-properties', function() { this.$('.toggle-properties').toggleClass('selected'); }, this);
        },

        events: {
            'click .hide-tools': function () { this.uiStateDispatcher.trigger('toggle-tools'); },
            'click .toggle-toolbox': function () { this.uiStateDispatcher.trigger('toggle-toolbox'); },
            'click .toggle-block-editor': function () { this.uiStateDispatcher.trigger('toggle-block-editor'); },
            'click .toggle-properties': function () { this.uiStateDispatcher.trigger('toggle-properties'); },
        },

        render: function () {
            this.$el.html(this.template());
            return this;
        }
    });
});
