define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'text!app/templates/StructureEditorTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    StructureEditorTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(StructureEditorTemplate),

        events: {
            'drop ': 'handleDrop'
        },

        render: function () {
            this.$el.html(this.template());
            //            this.$el.html(this.template(this.collection.toJSON()));
            this.$el.droppable({
                accept: "li.component",
                activeClass: "active",
                hoverClass: "hover"
            });

            _.each(this.model.get("components"),
            function (c) {
                alert(c.get("name")); 
            });

        },

        handleDrop: function (event, ui) {
            var component = new Component(this.model.componentsUrl());
            this.model.addComponent(component);
        }
    });
});