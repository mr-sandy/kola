define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/GridPlacementTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        gridNames: ['f', 'x', 'd', 't', 'p', 'm', 'u'],

        events: {
            'submit': function (e) { e.preventDefault(); this.trigger('submit'); },
            'click td.column': function (e) { $(e.target).toggleClass('selected'); },
            'click td.hidden': function (e) { $(e.target).toggleClass('selected'); },
            'click td.shown': function (e) { $(e.target).toggleClass('selected'); },
            'click button.reset': function (e) { $(e.target).closest('tr').find('td').removeClass('selected'); },
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

                if ($row.find('.shown.selected').length > 0) {
                    spec.shown = true;
                }

                if ($row.find('.hidden.selected').length > 0) {
                    spec.hidden = true;
                }

                var columns = $row.find('.column.selected');

                if (columns.length == 1) {
                    spec.position = columns.first().text().trim();
                }
                else if (columns.length > 1) {
                    var start = columns.first().text().trim();
                    var end = columns.last().text().trim();

                    spec.position = start + '-' + end;
                }

                if (spec.hidden || spec.shown || spec.position) {
                    result.push(spec);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(this.gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.columns = this.buildColumns(gridSettings.position);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildColumns: function (value) {
            var columns = _.map(_.range(1, 13), function (i) { return { index: i }; });

            if (value) {
                var start, end;
                if (value === 'all') {
                    start = 1;
                    end = 12;
                }
                else if (value.indexOf('-') > -1) {
                    var split = value.split('-');
                    start = parseInt(split[0]);
                    end = parseInt(split[1]);
                }
                else {
                    start = end = parseInt(value);
                }

                for (var i = start; i <= end; i++) {
                    columns[i - 1].selected = true;
                }
            }

            return columns;
        }
    });
});