define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');

    var WysiwygEditorView = require('app2/views/WysiwygEditorView');
    var BlockEditorView = require('app2/views/BlockEditorView');
    var AmendmentsView = require('app2/views/AmendmentsView');
    var ToolboxView = require('app2/views/ToolboxView');

    var Template = require('text!app2/templates/EditTemplateTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.options = options;

            this.amendmentsView = new AmendmentsView({
            });

            this.blockEditorView = new BlockEditorView({
            });

            this.wysiwygEditorView = new WysiwygEditorView({
            });

            this.toolboxView = new ToolboxView({
            });
        },

        render: function () {
            var context = {};
            this.$el.html(this.template(context));

            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendmentsView');
            this.assign(this.blockEditorView, '#blockEditorView');
            this.assign(this.wysiwygEditorView, '#wysiwygEditorView');
            this.assign(this.toolboxView, '#toolboxView');

            return this;
        }
    });
});