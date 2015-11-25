var Backbone = require('backbone');
var template = require('app/templates/AppTemplate.hbs');

module.exports = Backbone.View.extend({
    el: '#app',

    template: template,

    render: function () {
        this.$el.html(this.template());

        return this;
    }
});
