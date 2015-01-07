define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var ViewTemplate = require('text!/_kola/editors/templates/BooleanEditorViewTemplate.html');
    var EditTemplate = require('text!/_kola/editors/templates/BooleanEditorEditTemplate.html');

    return Backbone.View.extend({

        viewTemplate: Handlebars.compile(ViewTemplate),
        editTemplate: Handlebars.compile(EditTemplate),

        render: function (editMode) {

            var content = editMode ? this.editTemplate(this.model) : this.model.value.value;

            this.$el.html(content);

            return this;
        }
    });
});