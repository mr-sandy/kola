define([
    'backbone',
    'handlebars',
    'app/collections/Amendments',
    'app/views/AmendmentsView',
    'app/views/ComponentView',
    'app/views/ToolboxView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    Amendments,
    AmendmentsView,
    ComponentView,
    ToolboxView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            var amendments = new Amendments({ url: alert(this.model.amendmentsUrl) });
            this.amendmentsView = new AmendmentsView({
                collection: amendments
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

        loadAmendments: function () {
            alert("bonnus");
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendments');
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