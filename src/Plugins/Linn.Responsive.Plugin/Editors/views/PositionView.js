define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/PositionTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        positions: ['top', 'left', 'none', 'right', 'bottom', 'below'],

        events: {
            'click .position': 'togglePosition',
            'click select': 'handleSelectClick'
        },

        togglePosition: function (e) {
            var position = $(e.target).closest('.position');
            var grid = position.closest('[data-grid]');
            //            grid.find('.position').not(position).removeClass('selected');
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

            this.$el.find('.tabbed').tabbed({
                defaultTab: '#grid-x'
            });


            return this;
        },

        value: function () {
            var result = [];

            _.each(this.$el.find('.tab-contents > div'), function (row) {
                var $row = $(row);

                var positions = _.map($row.find('.position.selected'), function (position) {
                    var $position = $(position);

                    var gridPosition = {
                        position: $position.attr('data-position')
                    };

                    var offset = $position.find('select :selected');

                    if (offset.length == 1 && parseInt(offset.val()) > 0) {
                        gridPosition.offset = offset.val();
                    }

                    return gridPosition;
                });

                if (positions.length > 0) {
                    result.push({
                        grid: $row.attr('data-grid'),
                        positions: positions
                    });
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.positions = this.buildPositions(gridSettings.positions);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildPositions: function (positions) {
            var result = [];

            _.each(this.positions, function (positionName) {

                var position = _.find(positions, function (p) { return p.position === positionName; }) || { position: positionName, unset: true };

                if (position.unset != true) {
                    position.selected = true;
                }

                if (positionName !== 'none') {
                    position.offsets = this.buildOffsets(positionName, position.offset);
                }

                position.isNone = positionName === 'none';
                position.isBelow = positionName === 'below';

                result.push(position);

            }, this);

            return result;
        },

        buildOffsets: function (positionName, offset) {
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