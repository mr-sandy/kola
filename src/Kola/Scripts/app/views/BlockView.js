define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'app/views/BlockComponentView',
    'text!app/templates/BlockTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    BlockComponentView,
    BlockTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(BlockTemplate),

        render: function () {
            this.$el.html(this.template());

            this.$el.find("ul").sortable({
                opacity: 0.75,
                placeholder: "new",
                connectWith: "ul"
            });

            this.model.get("components").each(this.renderChild, this);

            return this;
        },

        renderChild: function (component) {
            this.assign(new BlockComponentView({ model: component }), this.$el.find("ul"));
        }
    });
});