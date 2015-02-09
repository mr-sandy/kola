define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/WidthTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        proportionalWidths: ['quarter', 'third', 'half', 'two-thirds', 'three-quarters', 'full'],

        fixedWidths: _.range(0, 101),

        events: {
            'click .width': 'toggleWidth',
            'click select': 'handleSelectClick'
        },

        toggleWidth: function (e) {
            var width = $(e.target).closest('.width');
            var grid = width.closest('[data-grid]');
            grid.find('.width').not(width).removeClass('selected');

            width.toggleClass('selected');
        },

        handleSelectClick: function (e) {
            e.stopPropagation();

            var width = $(e.target).closest('.width');
            var grid = width.closest('[data-grid]');
            grid.find('.width').not(width).removeClass('selected');

            $(e.target).closest('.width').addClass('selected');
        },


        render: function (editMode) {
            var model = this.model.value ? JSON.parse(this.model.value) : {};

            var viewModel = this.buildViewModel(model);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            this.$el.find('.tabbed').tabbed({
                defaultTab: '#grid-x'
            });

            return this;
        },

        value: function () {
            var result = [];

            _.each(this.$el.find('.tab-contents > div'), function (row) {
                var $row = $(row);

                var $width = $row.find('.width.selected');

                if ($width.length === 1) {

                    var width = {
                        type: $width.attr('data-type')
                    };

                    var value = $width.find(':selected').val();

                    if (value) {
                        width.value = value;
                    };

                    result.push(
                    {
                        grid: $row.attr('data-grid'),
                        width: width
                    });
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.widths = this.buildWidths(gridSettings.width);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildWidths: function (width) {
            var result = [];

            result.push(this.buildDefaultWidth(width));
            result.push(this.buildFixedWidths(width));
            result.push(this.buildProportionalWidths(width));

            return result;
        },

        buildDefaultWidth: function (width) {
            return {
                type: 'default',
                selected: width && width.type === 'default'
            };
        },

        buildFixedWidths: function (width) {
            var isSelected = width && width.type === 'fixed';

            var values = _.map(this.fixedWidths, function (value) {
                return {
                    value: value,
                    selected: isSelected && parseFloat(width.value) === value
                };
            });

            return {
                type: 'fixed',
                selected: isSelected,
                values: values
            };
        },

        buildProportionalWidths: function (width) {
            var isSelected = width && width.type === 'proportional';

            var values = _.map(this.proportionalWidths, function (value) {
                return {
                    value: value,
                    selected: isSelected && width.value === value
                };
            });

            return {
                type: 'proportional',
                selected: isSelected,
                values: values
            };
        }
    });
});