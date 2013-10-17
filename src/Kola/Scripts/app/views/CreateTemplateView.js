define([
    'backbone',
    'handlebars',
    'app/Config',
    'text!app/templates/CreateTemplateTemplate.html'
], function (Backbone,
    Handlebars,
    Config,
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

        save: function (e) {
            var self = this;

            e.preventDefault();

            var url = this.combineUrls(Config.kolaRoot, this.$('#path').val().trim());

            this.model.url = url;
            this.model.set('id', url);

            this.$el.find('button[type=submit]').button('saving');

            this.model.save().then(function () {
                self.options.router.navigate(self.model.url, { trigger: true });
            });
        }
    });
});