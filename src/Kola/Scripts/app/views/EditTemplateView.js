define([
    'backbone',
    'handlebars',
    'app/views/AmendmentsView',
    'app/views/ComponentView',
    'app/views/ToolboxView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    AmendmentsView,
    ComponentView,
    ToolboxView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            this.amendmentsView = new AmendmentsView({
                model: this.model.amendments
            });
            this.componentView = new ComponentView({
                model: this.model,
                isRoot: true 
            });
            this.toolboxView = new ToolboxView();
        },

        events: {
            'click #apply': 'apply',
            'click #undo': 'undo'
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.componentView, '#blockEditor');
            this.assign(this.componentView, '#blockEditor');
            this.assign(this.toolboxView, '#toolbox');
        },

        apply: function () {
            this.model.applyAmendments();
        },

        undo: function () {
            this.model.undoAmendment();
        }
    });
});