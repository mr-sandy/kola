define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/InnerTypeTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        types: ['left', 'full', 'right'],

        events: {
            'click .type': 'toggleType'
        },

        toggleType: function (e) {
            var type = $(e.target).closest('.type');
            var grid = type.closest('[data-grid]');
            grid.find('.type').not(type).removeClass('selected');

            type.toggleClass('selected');
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

                var $type = $row.find('.type.selected');
                if ($type.length === 1) {
                    result.push({
                        grid: $row.attr('data-grid'),
                        type: $type.attr('data-type')
                    });
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.types = this.buildTypes(gridSettings.type);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildTypes: function (type) {

            return _.map(this.types, function (t) {
                return {
                    type: t,
                    selected: t === type
                };
            });
        }
    });
});