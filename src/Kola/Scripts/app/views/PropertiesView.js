define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var Template = require('text!app/templates/PropertiesTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            this.$el.html(this.template());
            return this;
        }
    });
});