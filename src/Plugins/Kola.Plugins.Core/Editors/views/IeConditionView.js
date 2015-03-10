define(function (require) {
    'use strict';

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var _ = require('underscore');
    var Template = require('text!../templates/IeConditionTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'change': function () { this.trigger('submit'); },
            'focusout': function () { this.trigger('submit'); }
        },

        conditions: ['lte8', 'gt8', 'lt9', '9', 'gt9'],

        render: function (editMode) {
            var viewModel = this.buildViewModel(this.model.value);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find(':selected').val();
        },

        buildViewModel: function (value) {

            var conditions = _.map(this.conditions, function (condition) {
                return {
                    condition: condition,
                    selected: condition === value
                };
            });

            return {
                value: value,
                conditions: conditions
            };
        }
    });
});