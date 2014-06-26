define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var AreaView = require('app2/views/AreaView');
    var Template = require('text!app2/templates/WidgetTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {

            this.$el.html(this.template());

            var $list = this.$('ul').first();

            this.model.get('areas').each(function (area) {
                var areaView = new AreaView({ model: area });

                $list.append(areaView.render().$el.html());
            });

            return this;
        }
    });
});