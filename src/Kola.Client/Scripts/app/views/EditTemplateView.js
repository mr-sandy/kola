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

    var AmendmentBroker = require('app/views/AmendmentBroker');

    var Template = require('text!app/templates/EditTemplateTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {

            this.amendmentsView = new AmendmentsView({
                collection: this.model.amendments
            });

            this.blockEditorView = new BlockEditorView({
                model: this.model,
                amendmentBroker: new AmendmentBroker(this.model.amendments)
            });

            this.wysiwygEditorView = new WysiwygEditorView({
                model: this.model
            });

            this.propertiesView = new PropertiesView({
                amendments: this.model.amendments
            });

            this.toolboxView = new ToolboxView({
                collection: options.componentTypes
            });
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendments');
            this.assign(this.blockEditorView, '#block-editor');
            this.assign(this.wysiwygEditorView, '#wysiwyg-editor');
            this.assign(this.propertiesView, '#properties');
            this.assign(this.toolboxView, '#toolbox');

            this.$el.find('.tabbed').tabbed();

            return this;
        }
    });
});