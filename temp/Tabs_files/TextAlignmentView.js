define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/TextAlignmentTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'click .alignment': 'toggleAlignment'
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

                var alignment = $row.find('.alignment.selected');

                if (alignment.length == 1) {
                    spec.alignment = alignment.attr('data-alignment')
                    result.push(spec);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.alignments = this.buildAlignments(gridSettings.alignment);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildAlignments: function (value) {
            var alignments = [
            { name: "left" },
            { name: "centre" },
            { name: "right" }];

            if (value) {
                var selected = _.find(alignments, function (alignment) { return alignment.name === value; });
                if (selected) {
                    selected.selected = true;
                }
            }

            return alignments;
        },

        toggleAlignment: function (e) {
            var alignment = $(e.target).closest('.alignment');
            var grid = alignment.closest('[data-grid]');
            grid.find('.alignment').not(alignment).removeClass('selected');
            alignment.toggleClass('selected');
        }
    });
});