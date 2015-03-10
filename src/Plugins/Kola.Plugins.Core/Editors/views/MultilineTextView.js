define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/MultilineTextTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function (editMode) {

            var context = _.extend(this.model, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find('textarea').val();
        }
    });
});