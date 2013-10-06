define([
    'backbone',
    'handlebars',
    'app/views/ToolboxView',
    'app/views/ComponentView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    ToolboxView,
    ComponentView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            this.toolboxView = new ToolboxView();
            this.componentView = new ComponentView({
                model: this.model
            });
        },

        events: {
            'click #apply': 'apply'
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.toolboxView, '#toolbox');
            this.assign(this.componentView, '#blockEditor');
        },

        apply: function () {
            this.model.applyAmendments();
        }
    });
});