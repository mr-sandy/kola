define([
    'backbone',
    'handlebars',
    'text!app/templates/EditTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    EditTemplateTemplate) {

    "use strict";

    return Backbone.View.extend({

        template: Handlebars.compile(EditTemplateTemplate),

        render: function () {
            this.$el.html(this.template());
        }

//        events: {
//            'submit form': 'save'
//        },

//        updateAll: function () {
//            this.model.set({
//                'id': this.$('#path').val().trim(),
//                'path': this.$('#path').val().trim()
//            });
//        },

//        save: function (e) {
//            var self = this;

//            e.preventDefault();

//            this.updateAll();

//            this.$el.find('button[type=submit]').button('saving');

//            this.model.save({}, {
//                success: function (model) {
//                    self.options.router.navigate("_kola/templates/" + model.id, { trigger: true });
//                },
//                error: function (model, xhr) {
//                    alert("that's more like it");
//                }
//            });
//        }

    });
});