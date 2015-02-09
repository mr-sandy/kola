define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/FontTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        fontSizes: [16, 17, 18],

        fontWeights: ['normal', 'bold'],

        lineHeights: [0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10],

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

                settings.fontSize = $row.find('.font-size').val();

                settings.fontWeight = $row.find('.font-weight').val();

                settings.lineHeight = $row.find('.line-height').val();

                if (settings.fontSize || settings.fontWeight || settings.lineHeight) {
                    result.push(settings);
                }
            });

            return JSON.stringify(result);
        },

        buildViewModel: function (model) {
            var viewModel = { grids: [] };

            _.each(gridNames, function (gridName) {

                var gridSettings = _.find(model, function (m) { return m.grid === gridName; }) || { grid: gridName, unset: true };

                gridSettings.fontSizes = this.buildFontSizes(gridSettings.fontSize);

                gridSettings.fontWeights = this.buildFontWeights(gridSettings.fontWeight);

                gridSettings.lineHeights = this.buildLineHeights(gridSettings.lineHeight);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildFontSizes: function (fontSize) {

            return _.map(this.fontSizes, function (f) {
                return {
                    fontSize: f,
                    selected: parseFloat(fontSize) === f
                };
            });
        },

        buildFontWeights: function (fontWeight) {

            return _.map(this.fontWeights, function (f) {
                return {
                    fontWeight: f,
                    selected: fontWeight === f
                };
            });
        },

        buildLineHeights: function (lineHeight) {

            return _.map(this.lineHeights, function (l) {
                return {
                    lineHeight: l,
                    selected: parseFloat(lineHeight) === l
                };
            });
        }
    });
});