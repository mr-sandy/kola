define([
    'backbone',
    'handlebars',
    'app/collections/ComponentTypes',
    'text!app/templates/ToolboxTemplate.html'
], function (Backbone,
    Handlebars,
    ComponentTypes,
    ToolboxTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(ToolboxTemplate),

        initialize: function () {
            this.collection = new ComponentTypes();
        },

        render: function () {
            var $self = this;
            if (this.collection.size() == 0) {
                this.collection.fetch({ reset: true }).then(function () {
                    $self._doRender();
                });
            }
            else {
                this._doRender();
            }
        },

        _doRender: function () {
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