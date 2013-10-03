define([
    'backbone',
    'handlebars',
    'app/models/EventBroker',
    'app/views/ToolboxView',
    'app/views/ComponentView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    EventBroker,
    ToolboxView,
    ComponentView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            this.toolboxView = new ToolboxView();
            this.eventBroker = new EventBroker();
            this.componentView = new ComponentView({
                model: this.model,
                eventBroker: this.eventBroker
            });

            this.eventBroker.on('addComponent', function (data) { alert('addComponent') });
            this.eventBroker.on('moveComponent', function (data) { alert('moveComponent') });
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.toolboxView, '#toolbox');
            this.assign(this.componentView, '#blockEditor');
        }
    });
});