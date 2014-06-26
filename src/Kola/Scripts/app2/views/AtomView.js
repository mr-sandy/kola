define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app2/templates/AtomTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'atom',

        render: function () {
            this.$el.html(this.template(this.model.toJSON()));

            return this;
        }
    });
});