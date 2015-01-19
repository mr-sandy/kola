define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/BooleanEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'change': function () { this.trigger('submit'); },
            'focusout': function () { this.trigger('submit'); }
        },

        render: function (editMode) {
            if (editMode) {
                this.$el.html(this.template({ checkTrue: this.model.value.value === "true" }));
            }
            else {
                this.$el.html(this.model.value.value);
            }

            return this;
        },

        value: function () {
            return this.$el.find(':checked').val();
        }
    });
});