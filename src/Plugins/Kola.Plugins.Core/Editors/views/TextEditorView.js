define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/TextEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function (editMode) {
            if (editMode) {
                this.$el.html(this.template(this.model));
            }
            else {
                this.$el.html(this.model.value.value);
            }

            return this;
        },

        value: function () {
            return this.$el.find('input').val();
        }
    });
});