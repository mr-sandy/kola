var Backbone = require('backbone');
var template = require('app/templates/LoadingTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    render: function () {
        this.$el.html(this.template());
        return this;
    },

    show: function () {
        this.$el.fadeIn(100);
    },

    hide: function () {
        this.$el.fadeOut(100);
    }
});
