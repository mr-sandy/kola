define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/TriangleTemplate.html');

    require('../controls/Tabbed.js');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),


        events: {
            'click .edge': 'toggleEdge',
            'click .centred-switch': 'toggleCentred'
        },

        toggleEdge: function (e) {
            var edge = $(e.target).closest('.edge');
            var grid = edge.closest('[data-grid]');
            grid.find('.edge').not(edge).removeClass('selected');
            edge.toggleClass('selected');
        },

        toggleCentred: function (e) {
            var centred = $(e.target).closest('.centred-switch');
            var grid = centred.closest('[data-grid]');
            grid.find('.edge').toggleClass('centred');
            centred.toggleClass('selected');
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

                var spec = {
                    grid: $row.attr('data-grid')
                };

                if ($row.find('.centred-switch.selected').length > 0) {
                    spec.centred = true;
                }

                var edge = $row.find('.edge.selected');

                if (edge.length == 1) {
                    spec.edge = edge.attr('data-edge')
                    result.push(spec);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.edges = this.buildEdges(gridSettings.edge);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildEdges: function (value) {
            var edges = [
            { name: 'top' },
            { name: 'bottom' },
            { name: 'left' },
            { name: 'right'}];

            if (value) {
                var selected = _.find(edges, function (edge) { return edge.name === value; });
                if (selected) {
                    selected.selected = true;
                }
            }

            return edges;
        }
    });
});