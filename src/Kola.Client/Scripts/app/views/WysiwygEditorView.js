define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var _ = require('underscore');
    var WysiwygComponentView = require('app/views/WysiwygComponentView');
    var MaskView = require('app/views/MaskView');
    var domHelper = require('app/views/DomHelper');
    var Template = require('text!app/templates/WysiwygEditorTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function (options) {
            this.listenTo(this.model, 'sync', this.handleSync);

            this.previewUrl = _.first(this.model.previewUrls);

            this.maskView = new MaskView({ uiStateDispatcher: options.uiStateDispatcher });

            _.bindAll(this, 'buildChildren');

            this.children = [];
        },

        events: {
            'change select': 'changePreview'
        },

        changePreview: function() {
            this.previewUrl = $(this.el).find('select').val();
            this.fullRefresh();
        },

        handleSync: function () {
            // if the element is not inside the body tag, we need to reload the whole page
            if (this.$el.parents('body').length === 0) {
                this.fullRefresh();
            }
            else {
                alert('Is this called?');
                $.ajax({
                    url: this.previewUrl,
                    dataType: 'html',
                    context: this
                }).done(this.refresh);
            }
        },

        refresh: function (html) {
            this.$('iframe').contents().find('html').html(html);
            this.buildChildren();
        },

        fullRefresh: function () {
            this.destroyChildren();
            this.render();
        },

        render: function () {

            var previewUrl = this.previewUrl;
            var previewUrls = _.map(this.model.previewUrls, function (url) { return { url: url, selected: url === previewUrl } });

            var model = previewUrls.length > 1 ? previewUrls : null;

            this.$el.html(this.template(model));

            var $iframe = this.$('iframe');

            $iframe.on('load', this.buildChildren);
            $iframe.attr('src', this.previewUrl);

            return this;
        },

        buildChildren: function () {

            var $html = this.$('iframe').contents().find('html');

            $html.find('body').append(this.maskView.render().$el);

            this.destroyChildren();

            this.model.get('components').each(function (component) {
                var $elements = domHelper.findElements($html, component.get('path'));
                this.children.push(new WysiwygComponentView({
                    model: component,
                    previewUrl: this.previewUrl,
                    $html: $elements,
                    fullRefresh: $.proxy(this.fullRefresh, this),
                    maskView: this.maskView
                }));
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