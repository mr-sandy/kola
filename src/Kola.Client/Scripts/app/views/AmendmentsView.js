define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var _ = require('underscore');
    var Template = require('text!app/templates/AmendmentsTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function () {
            this.collection.on('sync', this.render, this);
        },

        events: {
            'click .apply': 'apply',
            'click .undo': 'undo'
        },

        render: function () {
            var context = _.extend(this.collection.toJSON(),
                { hasAmendments: this.collection.length > 0 }
            );

            this.$el.html(this.template(context));
            return this;
        },

        apply: function (e) {
            this.collection.applyAmendments();
        },

        undo: function() {
            this.collection.undoAmendment();
        }
    });
});