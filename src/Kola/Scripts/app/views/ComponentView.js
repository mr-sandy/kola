define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'app/views/ComponentView',
    'text!app/templates/RootComponentTemplate.html',
    'text!app/templates/ComponentTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    ComponentView,
    RootComponentTemplate,
    ComponentTemplate) {

    'use strict';

    return Backbone.View.extend({

        template: function (data) {
            return (this.isRoot)
                ? Handlebars.compile(RootComponentTemplate)(data)
                : Handlebars.compile(ComponentTemplate)(data);
        },

        initialize: function (args) {
            if (!ComponentView) { ComponentView = require('app/views/ComponentView'); }

            _.bindAll(this, 'handleStop');

            this.isRoot = args.isRoot;

            this.model.on('updated', this.render, this);
        },

        render: function (append) {
            var $element = $(this.template(this.model.omit('components')));

            this.$container = (this.isRoot)
                ? $element
                : $element.find('ul').filter(':first');

            this.$container.sortable({
                opacity: 0.75,
                placeholder: 'new',
                connectWith: 'ul',
                stop: this.handleStop
            });

            if (this.isRoot) {
                this.$el.html($element);
            }
            else {
                this.$el.replaceWith($element);
                this.$el = $element;
            }

            //            if (append) {
            //                this.$el.append($element);
            //            }
            //            else {
            //                this.$el.html($element);
            //            }

            this.model.get('components').each(this.renderChild, this);

            return this;
        },

        renderChild: function (component) {
            var view = new ComponentView({ model: component });
            this.$container.append('<li class="placeholder"></li>');
            view.setElement(this.$container.find('li.placeholder')).render(true);
        },

        handleStop: function (event, ui) {

            if (ui.item.attr('data-type') == 'toolbox-item') {
                this.model.addComponent(
                {
                    componentType: ui.item.attr('data-href'),
                    componentPath: ui.item.closest('[data-component-path]').attr('data-component-path'),
                    index: ui.item.index()
                });
            }
            else {
                this.model.moveComponent(
                {
                    componentPath: ui.item.attr('data-component-path'),
                    parentComponentPath: ui.item.parent().closest('[data-component-path]').attr('data-component-path'),
                    index: ui.item.index()
                });
            }
        }
    });
});
