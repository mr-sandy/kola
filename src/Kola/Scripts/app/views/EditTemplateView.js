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
            var amendments = new Amendments();

            this.amendmentsView = new AmendmentsView({
                collection: amendments
            });

            this.componentView = new ComponentView({
                model: this.model,
                isRoot: true,
                amendments: amendments
            });

            this.toolboxView = new ToolboxView();

            var self = this;
            this.listenToOnce(this.model, 'sync', function () {
                amendments.url = self.combineUrls(Config.kolaRoot, self.model.amendmentsUrl)
                amendments.fetch().done(function () { self.listenTo(amendments, 'sync', self.refresh); });
            });
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.amendmentsView, '#amendments');
            this.assign(this.componentView, '#blockEditor');
            this.assign(this.toolboxView, '#toolbox');
        },

        refresh: function (amendment) {
            this.model.refresh(amendment.get('subject'))
        }
    });
});