define([
    'backbone',
    'handlebars',
    'app/Config',
    'app/views/AmendmentsView',
    'app/views/ComponentView',
    'app/views/ToolboxView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    Config,
    AmendmentsView,
    ComponentView,
    ToolboxView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {

            this.amendmentsView = new AmendmentsView({
                collection: this.options.amendments
            });

            this.componentView = new ComponentView({
                model: this.model,
                amendments: this.options.amendments,
                isRoot: true
            });

            this.toolboxView = new ToolboxView(
            {
                collection: this.options.componentTypes
            });
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendments');
            this.assign(this.componentView, '#blockEditor');
            this.assign(this.toolboxView, '#toolbox');
        }
    });
});