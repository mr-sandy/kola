define(function (require) {
    'use strict';

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var _ = require('underscore');
    var Template = require('text!../templates/HtmlScriptTypeTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'change': function () { this.trigger('submit'); },
            'focusout': function () { this.trigger('submit'); }
        },

        scriptTypes: ['text/javascript'],

        render: function (editMode) {
            var viewModel = this.buildViewModel(this.model.value);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find(':selected').val();
        },

        buildViewModel: function (value) {

            var scriptTypes = _.map(this.scriptTypes, function (scriptType) {
                return {
                    scriptType: scriptType,
                    selected: scriptType === value
                };
            });

            return {
                value: value,
                scriptTypes: scriptTypes
            };
        }
    });
});