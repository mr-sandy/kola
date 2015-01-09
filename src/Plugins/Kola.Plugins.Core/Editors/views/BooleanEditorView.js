define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var ViewTemplate = require('text!../templates/BooleanEditorViewTemplate.html');
    var EditTemplate = require('text!../templates/BooleanEditorEditTemplate.html');

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