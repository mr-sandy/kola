define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/ResponsiveColourTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        gridNames: ['f', 'x', 'd', 't', 'p', 'm', 'u'],

        events: {
            'submit': function (e) { e.preventDefault(); this.trigger('submit'); }
        },

        render: function (editMode) {

            var model = this.model.value ? JSON.parse(this.model.value) : {};

            var viewModel = this.buildViewModel(model);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            var result = [];

            _.each($('table.edit tr'), function (row) {
                var $row = $(row);

                var selected = $row.find('select :selected');

                if (selected.length > 0 && selected.val()) {
                    result.push({
                        grid: $row.find('.grid').text().trim(),
                        colour: selected.val()
                    });

                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(this.gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.colours = this.buildColours(gridSettings.colour);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildColours: function (value) {
            var colours = [
            { name: "tint1" },
            { name: "tint2" },
            { name: "tint3" },
            { name: "secondary0" },
            { name: "secondary1" },
            { name: "secondary2" },
            { name: "secondary3" },
            { name: "white" },
            { name: "black" },
            { name: "pitch-black"}];

            if (value) {
                var selected = _.find(colours, function (colour) { return colour.name === value; });
                if (selected) {
                    selected.selected = true;
                }
            }

            return colours;
        }
    });
});