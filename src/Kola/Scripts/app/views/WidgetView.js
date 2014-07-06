define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var AreaView = require('app/views/AreaView');
    var Template = require('text!app/templates/WidgetTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        tagName: 'li',

        className: 'widget',

        initialize: function (options) {
            this.amendmentBroker = options.amendmentBroker;
            this.model.on('sync', this.render, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);
        },

        events: {
            "mouseover": "activate",
            "mouseout": "deactivate"
        },

        render: function () {
            var self = this;



            this.$el.html(this.template());
            this.$el.attr('data-component-path', this.model.get('path'));



            this.model.get('areas').each(function (area) {
                var areaView = new AreaView({ model: area,
                    amendmentBroker: self.amendmentBroker
                });

                self.$el.append(areaView.render().$el);
            });

            return this;
        },

        activate: function (e) {
            this.model.trigger('active');
            e.stopPropagation();
        },

        deactivate: function (e) {
            this.model.trigger('inactive');
            e.stopPropagation();
        },

        showActive: function () {
            this.$el.addClass('active');
        },

        showInactive: function () {
            this.$el.removeClass('active');
        }
    });
});