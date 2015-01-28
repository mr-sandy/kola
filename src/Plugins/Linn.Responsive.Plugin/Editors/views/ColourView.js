define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/ColourTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'change': function (e) { e.preventDefault(); this.trigger('submit'); },
            'focusout': function (e) { e.preventDefault(); this.trigger('submit'); }
        },

        render: function (editMode) {

            var viewModel = this.buildViewModel(this.model);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            var selected = this.$el.find('select :selected');

            if (selected.length > 0 && selected.val()) {
                return selected.val();
            }

            return '';
        },

        buildViewModel: function (model) {
            var viewModel = {
                value: model.value,
                colours:
             [
            { name: "tint1" },
            { name: "tint2" },
            { name: "tint3" },
            { name: "secondary0" },
            { name: "secondary1" },
            { name: "secondary2" },
            { name: "secondary3" },
            { name: "white" },
            { name: "black" },
            { name: "pitch-black"}]
            };

            if (model.value) {
                var selected = _.find(viewModel.colours, function (colour) { return colour.name === model.value; });
                if (selected) {
                    selected.selected = true;
                }
            }

            return viewModel;
        }
    });
});