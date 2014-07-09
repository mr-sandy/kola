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
            this.listenTo(this.model, 'sync', this.handleSync);

            _.bindAll(this, 'buildChildren');

            this.children = [];
        },

        handleSync: function () {
            $.ajax({
                url: '/_kola/preview/nelly',
                dataType: 'html',
                context: this
            }).done(this.refresh);
        },

        refresh: function (html) {

            this.$('iframe').contents().find('html').html(html);
            this.buildChildren();
        },

        render: function () {
            this.$el.html(this.template());

            var $iframe = this.$('iframe');

            $iframe.on('load', this.buildChildren);
            $iframe.attr('src', '/_kola/preview/nelly');

            return this;
        },

        buildChildren: function () {

            var $html = this.$('iframe').contents().find('html');

            this.destroyChildren();

            this.model.get('components').each(function (component) {
                var $elements = domHelper.findElements($html, component.get('path'));
                this.children.push(new WysiwygComponentView({ model: component, $html: $elements }));
            }, this);
        },

        destroyChildren: function () {
            var child;
            while (child = this.children.pop()) {
                child.destroy();
            }
        }
    });
});