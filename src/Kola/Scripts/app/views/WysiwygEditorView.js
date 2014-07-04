define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var WysiwygComponentView = require('app/views/WysiwygComponentView');
    var domHelper = require('app/views/DomHelper');
    var Template = require('text!app/templates/WysiwygEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
            _.bindAll(this, 'buildChildren');
        },

        refresh: function () {
            var self = this;
            var url = '/_kola/preview/nelly';

            var $html = $(this.$('iframe').contents()).find('html');

            $.ajax({
                url: url,
                dataType: 'html'
            }).done(function (data) {

                $html.html(data)
                self.buildChildren($html);
            })
        },

        render: function () {
            var self = this;
            this.$el.html(this.template());

            var $iframe = this.$('iframe');

            $iframe.load(function () {
                var $html = $($iframe.contents()).find('html');
                self.buildChildren($html);
            });

            $iframe.attr('src', '/_kola/preview/nelly');

            return this;
        },

        buildChildren: function ($html) {
            var self = this;

            self.model.get('components').each(function (component) {
                var $elements = domHelper.findElements($html.contents(), component.get('path'));

                var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                wysiwygComponentView.render();
            });
        }
    });
});