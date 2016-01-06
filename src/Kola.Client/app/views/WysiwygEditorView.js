var Backbone = require('backbone');
var $ = require('jquery');
var _ = require('underscore');
var WysiwygComponentView = require('app/views/WysiwygComponentView');
var MaskView = require('app/views/MaskView');
var domHelper = require('app/views/DomHelper');
var AddressBarComponent = require('app/components/wysiwyg/AddressBarComponent.jsx');
var template = require('app/templates/WysiwygEditorTemplate.hbs');
var React = require('react');
var ReactDOM = require('react-dom');

module.exports = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        _.bindAll(this, 'handlePreviewChange', 'buildChildren');

        this.listenTo(this.model, 'sync', this.handleSync);

        this.previewUrl = _.first(this.model.previewUrls);

        this.maskView = new MaskView({ uiStateDispatcher: options.uiStateDispatcher });

        this.children = [];
    },

    handlePreviewChange: function (previewUrl) {
        this.previewUrl = previewUrl;
        this.fullRefresh();
    },

    handleSync: function () {
        // if the element is not inside the body tag, we need to reload the whole page
        if (this.$el.parents('body').length === 0) {
            this.fullRefresh();
        }
        else {
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
        const showAddressBar = this.model.previewUrls.length > 1;
        const model = { showAddressBar: showAddressBar };

        this.$el.html(this.template(model));

        if (showAddressBar) {
            const $addressBar = this.$el.find('.address-bar').first();

            const props = {
                selectedUrl: this.previewUrl,
                candidateUrls: this.model.previewUrls,
                onChange: this.handlePreviewChange
            };

            this.reactComponent = ReactDOM.render(React.createElement(AddressBarComponent, props), $addressBar[0]);
        }

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
