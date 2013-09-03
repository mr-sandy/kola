define([
    'backbone',
    'handlebars',
    'app/views/ToolboxView',
    'app/views/StructureEditorView',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    ToolboxView,
    StructureEditorView,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        initialize: function () {

            this.toolboxView = new ToolboxView();
            this.structureEditorView = new StructureEditorView();
        },

        render: function () {
            this.$el.html(this.template());
            this.assign(this.toolboxView, '#toolbox');
            this.assign(this.structureEditorView, '#structureEditor');
        }
    });
});