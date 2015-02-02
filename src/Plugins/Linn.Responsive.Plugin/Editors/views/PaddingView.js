define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/PaddingTemplate.html');

    require('../controls/Tabbed.js');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

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

                gridSettings.edges = this.buildEdges(gridSettings.edges);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildEdges: function (edges) {
            var edgeNames = ['top', 'bottom', 'left', 'right'];

            var result = [];

            _.each(edgeNames, function (edgeName) {
                var edgeSettings = _.find(edges, function (e) { return e.edge === edgeName; }) || { edge: edgeName, unset: true };

                edgeSettings.values = this.buildValues(edgeSettings.value);

                result.push(edgeSettings);
            }, this);

            return result;
        },

        buildValues: function (value) {
            var vals = _.union(_.range(0, 10.5, 0.5), _.range(11, 29));

            var result = [];

            _.each(vals, function (val) {
                result.push({
                    value: val,
                    selected: val === parseFloat(value)
                });
            }, this);

            return result;
        }
    });
});