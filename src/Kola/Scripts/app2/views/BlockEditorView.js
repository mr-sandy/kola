define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    require('jqueryui');
    var Template = require('text!app2/templates/BlockEditorTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        render: function () {
            this.$el.html(this.template());

            this.model.get('components').each(function (component) {
                alert(component.get('links').length);
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
        }
    });
});