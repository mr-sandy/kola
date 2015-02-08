define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!../templates/IconTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        icons: ['burger', 'badger'],

        events: {
            'focusout': function () { this.trigger('submit'); }
        },

        render: function (editMode) {
            var viewModel = this.buildViewModel(this.model.value);

            var context = _.extend(viewModel, { editMode: editMode });

            this.$el.html(this.template(context));

            return this;
        },

        value: function () {
            return this.$el.find('select').val();
        },

        buildViewModel: function (value) {

            return {
                value: value,
                icons: _.map(this.icons, function (i) {
                    return {
                        icon: i,
                        selected: i === value
                    };
                })
            };
        }
    });
});