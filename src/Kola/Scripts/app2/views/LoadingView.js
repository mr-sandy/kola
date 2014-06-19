define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app2/templates/LoadingTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            this.$el.html(this.template({ }));

//            if (this.options.hide) {
//                this.$el.hide();
//            }

            return this;
        },

        show: function () {
            this.$el.fadeIn(100);
        },

        hide: function () {
            this.$el.fadeOut(100);
        }
    });
});