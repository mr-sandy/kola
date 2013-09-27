define([
    'backbone',
    'handlebars',
    'app/views/ToolboxView',
    'app/views/BlockView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    ToolboxView,
    BlockView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {
            this.toolboxView = new ToolboxView();
            this.blockView = new BlockView({
                model: this.model
            });
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.toolboxView, '#toolbox');
            this.assign(this.blockView, '#blockEditor');
        }
    });
});