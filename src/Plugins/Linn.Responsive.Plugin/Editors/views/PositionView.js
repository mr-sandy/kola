define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/PositionTemplate.html');

    require('../controls/Tabbed.js');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'click .position': 'togglePosition',
            'click select': 'handleSelectClick'
        },

        togglePosition: function (e) {
            var position = $(e.target).closest('.position');
            var grid = position.closest('[data-grid]');
            grid.find('.position').not(position).removeClass('selected');
            position.toggleClass('selected');
        },

        handleSelectClick: function (e) {
            e.stopPropagation();
            $(e.target).closest('.position').addClass('selected');
        },

        render: function (editMode) {
            var model = this.model.value ? JSON.parse(this.model.value) : {};

            var viewModel = this.buildViewModel(model);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            this.$el.find('.tabbed').tabbed();

            return this;
        },

        value: function () {
            var result = [];

            _.each(this.$el.find('.tab-contents > div'), function (row) {
                var $row = $(row);

                var position = $row.find('.position.selected');

                if (position.length == 1) {
                    var offset = position.find('select');

                    var gridPosition =
                    {
                        grid: $row.attr('data-grid'),
                        position: position.attr('data-position')
                    };

                    if (offset.length == 1) {
                        gridPosition.offset = offset.val();
                    }

                    result.push(gridPosition);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.positions = this.buildPositions(gridSettings);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildPositions: function (gridSettings) {
            var positions = ['top left', 'top', 'top right', 'left', 'none', 'right', 'bottom left', 'bottom', 'bottom right', 'below'];

            var result = _.map(positions, function (pos) {

                return {
                    position: pos,
                    selected: pos === gridSettings.position,
                    isNone: pos === 'none',
                    offsets: pos === 'below' ? this.buildOffsets(gridSettings.offset) : null
                };
            }, this);

            return result;
        },

        buildOffsets: function (offset) {
            var offsets = _.range(1, 21);

            return _.map(offsets, function (o) {

                return {
                    offset: o,
                    selected: o === parseInt(offset)
                };
            });
        }
    });
});