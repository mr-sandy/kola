var Backbone = require('backbone');
var template = require('app/templates/ViewTemplatesTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    render: function () {
        this.$el.html(this.template());
        return this;
    }
});
