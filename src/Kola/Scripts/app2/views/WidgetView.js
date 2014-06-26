define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var AreaView = require('app2/views/AreaView');
    var Template = require('text!app2/templates/WidgetTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'widget',

        render: function () {

            var self = this;

            this.$el.html(this.template());

            this.model.get('areas').each(function (area) {
                var areaView = new AreaView({ model: area });

                self.$el.append(areaView.render().$el);
            });

            return this;
        }
    });
});