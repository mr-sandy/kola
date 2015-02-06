define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/FloatTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        floats: ['left', 'right', 'none'],

        clears: ['left'],

        events: {
            'click .float': 'toggleFloat',
            'click .clearr': 'toggleClear'
        },

        toggleFloat: function (e) {
            var float = $(e.target).closest('.float');
            var grid = float.closest('[data-grid]');
            grid.find('.float').not(float).removeClass('selected');

            float.toggleClass('selected');
        },

        toggleClear: function (e) {
            var clear = $(e.target).closest('.clearr');
            var grid = clear.closest('[data-grid]');
            grid.find('.clearr').not(clear).removeClass('selected');

            clear.toggleClass('selected');
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

                var settings = {
                    grid: $row.attr('data-grid')
                };

                var $float = $row.find('.float.selected');
                if ($float.length === 1) {
                    settings.float = $float.attr('data-float');
                }

                var $clear = $row.find('.clearr.selected');
                if ($clear.length === 1) {
                    settings.clear = $clear.attr('data-clear');
                }

                if (settings.float || settings.clear) {
                    result.push(settings);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.floats = this.buildFloats(gridSettings.float);

                gridSettings.clears = this.buildClears(gridSettings.clear);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildFloats: function (float) {

            return _.map(this.floats, function (f) {
                return {
                    float: f,
                    selected: f === float
                };
            });
        },

        buildClears: function (clear) {

            return _.map(this.clears, function (c) {
                return {
                    clear: c,
                    selected: c === clear
                };
            });
        } 
    });
});