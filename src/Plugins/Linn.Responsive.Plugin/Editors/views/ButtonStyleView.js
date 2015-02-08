define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/ButtonStyleTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        buttonStyles: ['primary-menu', 'badger'],

        events: {
            'focusout': function () { this.trigger('submit'); }
        },

        render: function (editMode) {
            var viewModel = this.buildViewModel(this.model.value);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find('select').val();
        },

        buildViewModel: function (value) {

            return {
                value: value,
                buttonStyles: _.map(this.buttonStyles, function (i) {
                    return {
                        buttonStyle: i,
                        selected: i === value
                    };
                })
            };
        }
    });
});