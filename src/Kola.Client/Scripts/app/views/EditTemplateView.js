define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');

    var WysiwygEditorView = require('app/views/WysiwygEditorView');
    var BlockEditorView = require('app/views/BlockEditorView');
    var AmendmentsView = require('app/views/AmendmentsView');
    var PropertiesView = require('app/views/PropertiesView');
    var ToolboxView = require('app/views/ToolboxView');
    var SidebarView = require('app/views/SidebarView');

    var AmendmentBroker = require('app/views/AmendmentBroker');

    var Template = require('text!app/templates/EditTemplateTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {

            this.uiStateDispatcher = _.clone(Backbone.Events)

            this.sidebarView = new SidebarView({
                uiStateDispatcher: this.uiStateDispatcher
            });

            this.amendmentsView = new AmendmentsView({
                collection: this.model.amendments
            });

            this.blockEditorView = new BlockEditorView({
                model: this.model,
                amendmentBroker: new AmendmentBroker(this.model.amendments),
                uiStateDispatcher: this.uiStateDispatcher
            });

            this.wysiwygEditorView = new WysiwygEditorView({
                model: this.model,
                uiStateDispatcher: this.uiStateDispatcher
            });

            this.propertiesView = new PropertiesView({
                amendments: this.model.amendments,
                uiStateDispatcher: this.uiStateDispatcher
            });

            this.toolboxView = new ToolboxView({
                collection: options.componentTypes,
                uiStateDispatcher: this.uiStateDispatcher
            });

            this.uiStateDispatcher.on('toggle-tools', function () { this.$('.show-tools, .toolbars').toggleClass('hidden'); }, this);
            this.uiStateDispatcher.on('toggle-pin-toolbars', function () { this.$('.toolbars').toggleClass('pinned'); }, this);
        },

        events: {
            'click .show-tools': function () { this.uiStateDispatcher.trigger('toggle-tools'); }
        },

        render: function () {
            this.$el.html(this.template());

            this.assign(this.sidebarView, '.sidebar');
            this.assign(this.toolboxView, '.toolbars .toolbox');
            this.assign(this.blockEditorView, '.toolbars .block-editor');
            this.assign(this.propertiesView, '.toolbars .properties');
            this.assign(this.wysiwygEditorView, '.preview');

            //            this.assign(this.amendmentsView, '#amendments');

            return this;
        }
    });
});