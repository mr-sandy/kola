define([
    'backbone',
    'handlebars',
    'text!app/templates/ToolboxTemplate.html'
], function (Backbone,
    Handlebars,
    ToolboxTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(ToolboxTemplate),

        initialize: function () {
            this.listenTo(this.collection, 'sync', this.render);
        },

        render: function () {
            this.$el.html(this.template(this.collection.toJSON()));
            this.$el.find("li").draggable(
            {
                opacity: 0.7,
                helper: "clone",
                connectToSortable: "#blockEditor ul"
            });
        }
    });
});
