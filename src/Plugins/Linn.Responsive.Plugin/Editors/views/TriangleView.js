define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/TriangleTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        gridNames: ['f', 'x', 'd', 't', 'p', 'm', 'u'],

        events: {
            'submit': function (e) { e.preventDefault(); this.trigger('submit'); },
            'click td.edge': function (e) { $(e.target).toggleClass('selected'); },
            'click td.centred': function (e) { $(e.target).toggleClass('selected'); },
            'click button.reset': function (e) { $(e.target).closest('tr').find('td').removeClass('selected'); }
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

                var spec = {
                    grid: $row.find('.grid').text().trim()
                };

                if ($row.find('.centred.selected').length > 0) {
                    spec.centred = true;
                }

                var edge = $row.find('.edge.selected');

                if (edge.length == 1) {
                    spec.edge = edge.first().text().trim();
                    result.push(spec);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(this.gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.edges = this.buildEdges(gridSettings.edge);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildEdges: function (value) {
            var edges = [
            { name: 'top' },
            { name: 'right' },
            { name: 'bottom' },
            { name: 'left'}];

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