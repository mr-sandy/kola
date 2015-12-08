var Backbone = require('backbone');
var _ = require('underscore');
var template = require('app/templates/AmendmentsTemplate.hbs');


module.exports = Backbone.View.extend({

    template: template,

    initialize: function () {
        this.collection.on('sync', this.render, this);
    },

    events: {
        'click .apply': 'apply',
        'click .undo': 'undo'
    },

    render: function () {
        var context = _.extend(this.collection.toJSON(),
            {
                hasAmendments: this.collection.length > 0,
                count: this.collection.length
            }
        );

        this.$el.html(this.template(context));

        return this;
    },

    apply: function (e) {
        this.collection.applyAmendments();
    },

    undo: function () {
        this.collection.undoAmendment();
    }
});