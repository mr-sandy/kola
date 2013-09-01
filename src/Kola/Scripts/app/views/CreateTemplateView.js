define([
    'backbone',
    'handlebars',
    'text!app/templates/CreateTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    CreateTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(CreateTemplateTemplate),

        render: function () {
            this.$el.html(this.template());
        },

        events: {
            'submit form': 'save'
        },

        updateAll: function () {
            this.model.set({
                'id': this.$('#path').val().trim(),
                'path': this.$('#path').val().trim()
            });
        },

        save: function (e) {
            var self = this;

            e.preventDefault();

            this.updateAll();

            this.$el.find('button[type=submit]').button('saving');

            this.model.save({}, {
                success: function (model) {
                    alert("really?");
                    //                    self.options.router.navigate(self.transformForRouter(config.rootUrl, model.id), { trigger: true });
                },
                error: function (model, xhr) {
                    alert("that's more like it");
                }
            });
        }

    });
});