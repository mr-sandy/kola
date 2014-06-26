define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var componentViewFactory = require('app2/views/ComponentViewFactory');
    var $ = require('jquery');
    require('jqueryui');
    var Template = require('text!app2/templates/BlockEditorTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            this.$el.html(this.template());

            var $list = this.$('ul').first();

            this.model.get('components').each(function (component) {
                var childView = componentViewFactory.build(component);

                $list.append(childView.render().$el);
            });

            this.$('ul').sortable({
                opacity: 0.75,
                placeholder: 'new',
                connectWith: 'ul',
                stop: this.handleStop
            });

            return this;
        },

        handleStop: function (event, ui) {

            if (ui.item.hasClass('tool')) {
                alert('Add component');
            }
            else {
                alert('Move component');
            }

            ui.item.trigger($.Event("boom"));
        }
    });
});