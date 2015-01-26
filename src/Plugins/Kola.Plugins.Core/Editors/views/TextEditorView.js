define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/TextEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'focusout': function () { this.trigger('submit'); },
            'submit': function () { this.trigger('submit'); }
        },

        render: function (editMode) {

            var context = _.extend(this.model, { editMode: editMode });

            this.$el.html(this.template(context));

            if (editMode) {
                var input = this.$el.find('input');
                input.focus();
                input[0].setSelectionRange(0, input.val().length);
            }

            return this;
        },

        value: function () {
            return this.$el.find('input').val();
        }
    });
});