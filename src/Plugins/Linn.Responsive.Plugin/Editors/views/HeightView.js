define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/HeightTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        proportionalHeights: ['quarter', 'third', 'half', 'two-thirds', 'three-quarters', 'full'],

        fixedHeights: _.union(_.range(0, 10.5, 0.5), _.range(11, 101)),

        events: {
            'click .height': 'toggleHeight',
            'click select': 'handleSelectClick'
        },

        toggleHeight: function (e) {
            var height = $(e.target).closest('.height');
            var grid = height.closest('[data-grid]');
            grid.find('.height').not(height).removeClass('selected');

            height.toggleClass('selected');
        },

        handleSelectClick: function (e) {
            e.stopPropagation();

            var height = $(e.target).closest('.height');
            var grid = height.closest('[data-grid]');
            grid.find('.height').not(height).removeClass('selected');

            $(e.target).closest('.height').addClass('selected');
        },


        render: function (editMode) {
            var model = this.model.value ? JSON.parse(this.model.value) : {};

            var viewModel = this.buildViewModel(model);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            this.$el.find('.tabbed').tabbed({
                defaultTab: '#grid-xxl'
            });

            return this;
        },

        value: function () {
            var result = [];

            _.each(this.$el.find('.tab-contents > div'), function (row) {
                var $row = $(row);

                var $height = $row.find('.height.selected');

                if ($height.length === 1) {

                    var height = {
                        type: $height.attr('data-type')
                    };

                    var value = $height.find(':selected').val();

                    if (value) {
                        height.value = value;
                    };

                    result.push(
                    {
                        grid: $row.attr('data-grid'),
                        height: height
                    });
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.heights = this.buildHeights(gridSettings.height);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildHeights: function (height) {
            var result = [];

            result.push(this.buildDefaultHeight(height));
            result.push(this.buildFixedHeights(height));
            result.push(this.buildProportionalHeights(height));
            result.push(this.buildViewHeightHeights(height));

            return result;
        },

        buildDefaultHeight: function (height) {
            return {
                type: 'default',
                selected: height && height.type === 'default'
            };
        },

        buildFixedHeights: function (height) {
            var isSelected = height && height.type === 'fixed';

            var values = _.map(this.fixedHeights, function (value) {
                return {
                    value: value,
                    selected: isSelected && parseFloat(height.value) === value
                };
            });

            return {
                type: 'fixed',
                selected: isSelected,
                values: values
            };
        },

        buildProportionalHeights: function (height) {
            var isSelected = height && height.type === 'proportional';

            var values = _.map(this.proportionalHeights, function (value) {
                return {
                    value: value,
                    selected: isSelected && height.value === value
                };
            });

            return {
                type: 'proportional',
                selected: isSelected,
                values: values
            };
        },

        buildViewHeightHeights: function (height) {
            var isSelected = height && height.type === 'view-height';

            var values = _.map(this.proportionalHeights, function (value) {
                return {
                    value: value,
                    selected: isSelected && height.value === value
                };
            });

            return {
                type: 'view-height',
                selected: isSelected,
                values: values
            };
        }
    });
});