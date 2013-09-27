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

        events: {
            'drop ': 'handleDrop'
        },

        render: function () {
            var self = this;

            if (!BlockComponentView) {
                BlockComponentView = require('app/views/BlockComponentView');
            }

            var data = this.model.omit("components");
            this.$element = $(this.template(data));
            this.$el.append(this.$element);

            this.model.get("components").each(
                function (component) {
                    var view = new BlockComponentView({
                        model: component
                    });

                    self.assign(view, self.$element.find("ul"));
                }
            );

            return this;
        },

        handleDrop: function (event, ui) {
            //            var component = new Component(this.model.componentsUrl());
            //            this.model.addComponent(component);
        }
    });
});


//this.$element.droppable({
//    accept: "li.component",
//    activeClass: "active",
//    hoverClass: "hover",
//    greedy: true
//});
