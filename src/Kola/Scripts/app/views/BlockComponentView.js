define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'app/views/BlockComponentView',
    'text!app/templates/BlockComponentTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    BlockComponentView,
    BlockComponentTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(BlockComponentTemplate),

        initialize: function (args) {
            _.bindAll(this, 'handleStop');
        },

        render: function () {
            var self = this;

            if (!BlockComponentView) {
                BlockComponentView = require('app/views/BlockComponentView');
            }

            var data = this.model.omit("components");
            this.$element = $(this.template(data));
            this.$el.append(this.$element);

            this.$element.find("ul").sortable({
                opacity: 0.75,
                placeholder: "new",
                connectWith: "ul",
                stop: this.handleStop
            });

            this.model.get("components").each(this.renderChild, this);

            return this;
        },

        renderChild: function(component) {
            this.assign(new BlockComponentView({ model: component }), this.$element.find("ul"));
        },

        handleStop: function (event, ui) {
            var component = new Component();
            this.model.get("components").add(component, { at: ui.item.index() });
        }
    });
});
