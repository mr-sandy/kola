define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var ViewTemplate = require('text!/_kola/editors/templates/BooleanEditorViewTemplate.html');
    var EditTemplate = require('text!/_kola/editors/templates/BooleanEditorEditTemplate.html');

    return Backbone.View.extend({

        viewTemplate: Handlebars.compile(ViewTemplate),
        editTemplate: Handlebars.compile(EditTemplate),

        initialize: function () {
            this.mode = 'view';
        },

        events: {
            'click .value': 'edit',
            'click .save': 'save'
        },

        render: function () {
            if (this.mode === 'edit') {
                this.$el.find('.value').html(this.editTemplate(this.model));
            }
            else {
                this.$el.find('.value').html(this.viewTemplate(this.model));
            }

            return this;
        },

        edit: function (e) {
            if (this.mode != 'edit') {
                this.mode = 'edit';
                this.render();
            }
        },

        save: function (e) {
            var value = $('input[name=value]:checked').val();
            this.trigger('change', value);
        }
    });
});