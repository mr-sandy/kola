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
                    propertyEditorView.test();
                    //                PropertyView.test();
                });
            }
        },

        initialize: function (options) {
            this.stateBroker = options.stateBroker;
            this.listenTo(options.stateBroker, 'change', this.render);
        },

        render: function () {

            // should probably go and find a property viewer/editor for each parameter then render them all?
            // NOTE: the selected component will only contain entries for parameters for which values have been set;
            // probably need to retrieve all the possble parameters for the copmonent (get them all in one call?)
            // what about grouping them?
            if (this.stateBroker.selected) {
                _.each(this.stateBroker.selected.get('parameters'), function (parameter) {
                    // var propertyUri = '/_kola/editors/views/' + parameter.type + '.js'
                    // require([propertyUri], function (PropertyEditorView) {
                    //     var propertyEditorView = new PropertyEditorView();
                    //     //                PropertyView.test();
                    // });
                    alert(parameter.type);
                });
            }

            var context = this.stateBroker.selected ? this.stateBroker.selected.toJSON() : {};
            this.$el.html(this.template(context));
            return this;
        }
    });
});