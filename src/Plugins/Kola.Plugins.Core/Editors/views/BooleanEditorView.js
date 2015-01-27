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

            var context = _.extend(this.model, { editMode: editMode, checkTrue: this.model.value === "true" });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find(':checked').val();
        }
    });
});