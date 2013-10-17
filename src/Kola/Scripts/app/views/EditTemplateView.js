define([
    'backbone',
    'handlebars',
    'app/Config',
    'app/collections/Amendments',
    'app/views/AmendmentsView',
    'app/views/ComponentView',
    'app/views/ToolboxView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    Config,
    Amendments,
    AmendmentsView,
    ComponentView,
    ToolboxView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            var self = this;

            this.amendments = new Amendments([], { url: this.combineUrls(Config.kolaRoot, this.model.amendmentsUrl) });
            this.amendmentsView = new AmendmentsView({
                collection: this.amendments
            });
            this.componentView = new ComponentView({
                model: this.model,
                isRoot: true,
                amendments: this.amendments
            });
            this.toolboxView = new ToolboxView();

            this.amendments.fetch().done(function () { self.listenTo(self.amendments, 'sync', self.refresh); });


        },

        events: {
            'click #apply': 'apply',
            'click #undo': 'undo'
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendments');
            this.assign(this.componentView, '#blockEditor');
            this.assign(this.toolboxView, '#toolbox');
        },

        apply: function () {
            this.amendments.apply();
        },

        undo: function () {
            this.model.undo();
        },

        refresh: function (amendment) {
            this.model.refresh(amendment.subject)
        }
    });
});