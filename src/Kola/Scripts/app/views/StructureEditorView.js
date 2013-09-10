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
        },

        handleDrop: function (event, ui) {
            //            alert(ui.draggable.text());
            var component = new Component();
            component.url = this.model.url();
            this.model.addComponent(component);
            //alert(this.model.get("id"));
        }
    });
});