define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var Template = require('text!app2/templates/ToolboxTemplate.html');

    require('jqueryui');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            var context = this.collection.toJSON();
            this.$el.html(this.template(context));

            this.$("li").draggable(
            {
                opacity: 0.7,
                iframeFix: true,
                helper: "clone",
                connectToSortable: ".component-type-target"
            });

            return this;
        }
    });
});