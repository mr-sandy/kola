define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');
    var Handlebars = require('handlebars');
    var gridNames = require('./GridNames.js')
    var Template = require('text!../templates/BorderStyleTemplate.html');

    require('tabbed');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        widths: ['none', 'hair', 'fine', 'reg', 'thick'],

        events: {
            'change select': 'handleSelectChange'
        },

        handleSelectChange: function (e) {
            var $select = $(e.target);
            var $preview = $select.closest('[data-grid]').find('.preview');

            var border = $select.attr('data-border');
            var width = $select.val();

            var classes = _.map(this.widths, function (w) { return border + '-' + w; }).join(' ');

            $preview.removeClass(classes);
            $preview.addClass(border + '-' + width);
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


                var borders = _.map($row.find('select.border'), function (border) {
                    var $border = $(border);
                    return {
                        border: $border.attr('data-border'),
                        width: $border.find(':selected').val()
                    }
                });

                var bordersWithWidth = _.filter(borders, function (border) {
                    return border.width;
                });

                if (bordersWithWidth.length > 0) {
                    result.push(
                    {
                        grid: $row.attr('data-grid'),
                        borders: bordersWithWidth
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

                gridSettings.borders = this.buildBorders(gridSettings.borders);

                gridSettings.previewClasses = this.buildPreviewClasses(gridSettings.borders);

                viewModel.grids.push(gridSettings);

            }, this);

            return viewModel;
        },

        buildBorders: function (borders) {
            var borderNames = ['top', 'bottom', 'left', 'right'];

            var result = [];

            _.each(borderNames, function (borderName) {
                var borderSettings = _.find(borders, function (e) { return e.border === borderName; }) || { border: borderName, unset: true };

                borderSettings.widths = this.buildWidths(borderSettings.width);

                result.push(borderSettings);
            }, this);

            return result;
        },

        buildPreviewClasses: function (borders) {
            var result = [];

            _.each(borders, function (border) {
                if (border.width) {
                    result.push(border.border + '-' + border.width);
                }
            }, this);

            return result.join(' ');
        },

        buildWidths: function (width) {

            var result = [];

            _.each(this.widths, function (w) {
                result.push({
                    width: w,
                    selected: w === width
                });
            }, this);

            return result;
        }
    });
});