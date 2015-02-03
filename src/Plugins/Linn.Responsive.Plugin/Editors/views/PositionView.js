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
            'click .toggle-switch': 'toggle',
            'click select': 'handleSelectClick'
        },

        toggle: function (e) {
            var position = $(e.target).closest('.toggle-switch');
            var grid = position.closest('[data-grid]');
            grid.find('.toggle-switch').not(position).removeClass('selected');
            position.toggleClass('selected');
        },

        handleSelectClick: function (e) {
            e.stopPropagation();
            $(e.target).closest('.toggle-switch').addClass('selected');
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


                var edges = _.map($row.find('select.edge'), function (edge) {
                    var $edge = $(edge);
                    return {
                        edge: $edge.attr('data-edge'),
                        value: $edge.find(':selected').val()
                    }
                });

                var edgesWithValue = _.filter(edges, function (edge) {
                    return edge.value;
                });

                if (edgesWithValue.length > 0) {
                    result.push(
                    {
                        grid: $row.attr('data-grid'),
                        edges: edgesWithValue
                    }
                    );
                }
            });

            var x = JSON.stringify(result);
            return x;
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
                    selected: o === offset
                };
            });
        }
    });
});