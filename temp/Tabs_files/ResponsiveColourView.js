define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/ResponsiveColourTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'click .preview': 'setPreviewColour',
            'click .colour': 'toggleColour'
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

            _.each($('.row[data-grid]'), function (row) {
                var $row = $(row);

                var spec = {
                    grid: $row.attr('data-grid')
                };

                var colour = $row.find('.colour.selected');

                if (colour.length == 1) {
                    spec.colour = colour.attr('data-colour')
                    result.push(spec);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

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
        },

        toggleColour: function (e) {
            var colour = $(e.target).closest('.colour');
            var grid = colour.closest('[data-grid]');
            grid.find('.colour').not(colour).removeClass('selected');
            colour.toggleClass('selected');
        },

        setPreviewColour: function (e) {
            var previewColour = $(e.target).attr('data-preview-colour');
            this.$el.find('.row[data-grid]').removeClass('red orange blue green purple').addClass(previewColour);
            $(e.target).siblings().removeClass('selected');
            $(e.target).addClass('selected');
        }
    });
});