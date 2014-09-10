define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var Template = require('text!app/templates/PropertiesTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        events: {
            'click .value': function () {

                var propertyEditorUri = '/_kola/editors/views/MarkdownEditorView.js'
                require([propertyEditorUri], function (PropertyEditorView) {
                    var propertyEditorView = new PropertyEditorView();
                    //                PropertyView.test();
                });
            }
        },

        initialize: function (options) {
            this.stateBroker = options.stateBroker;
            this.listenTo(options.stateBroker, 'change', this.render);
        },

        render: function () {
            var context = this.stateBroker.selected ? this.stateBroker.selected.toJSON() : {};
            this.$el.html(this.template(context));
            return this;
        }
    });
});