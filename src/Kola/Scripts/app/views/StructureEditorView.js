define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'app/views/StructureEditorView',
    'text!app/templates/StructureEditorTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    StructureEditorView,
    StructureEditorTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(StructureEditorTemplate),

        events: {
            'drop ': 'handleDrop'
        },

        render: function () {
            var self = this;

            if (!StructureEditorView) {
                StructureEditorView = require('app/views/StructureEditorView');
            }
            var data = this.model.omit("components");
            this.$element = $(this.template(data));
            this.$element.droppable({
                accept: "li.component",
                activeClass: "active",
                hoverClass: "hover",
                greedy: true
            });
            this.$el.append(this.$element);

            //            this.$el.html(this.template(this.collection.toJSON()));
            //            this.$el.droppable({
            //                accept: "li.component",
            //                activeClass: "active",
            //                hoverClass: "hover"
            //            });

            this.model.get("components").each(
                function (component) {
                    var view = new StructureEditorView({
                        model: component
                    });

                    self.assign(view, self.$element);
                }
            );

            return this;
        },

        handleDrop: function (event, ui) {
            var component = new Component(this.model.componentsUrl());
            this.model.addComponent(component);
        }
    });
});