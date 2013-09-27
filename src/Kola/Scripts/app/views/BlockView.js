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
            var self = this;

            this.$el.html(this.template());

            this.model.get("components").each(
                            function (component) {
                                var view = new BlockComponentView({
                                    model: component
                                });

                                self.assign(view, self.$el.find("ul"));
                            }
                        );

            self.$el.find("ul").sortable({
                placeholder: "new",
                connectWith: "ul"
            });

            return this;
        }
    });
});