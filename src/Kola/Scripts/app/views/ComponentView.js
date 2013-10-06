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
            return (this.isChild)
                ? Handlebars.compile(ComponentTemplate)(data)
                : Handlebars.compile(RootComponentTemplate)(data);
        },

        initialize: function (args) {
            _.bindAll(this, 'handleStop');

            this.isChild = args.isChild;

            if (!ComponentView) {
                ComponentView = require('app/views/ComponentView');
            }

            this.model.on('change', this.render, this);
        },

        render: function () {
            var $element = $(this.template(this.model.omit('components')));

            this.$container = (this.isChild)
                ? $element.find('ul').filter(':first')
                : $element;

            this.$container.sortable({
                opacity: 0.75,
                placeholder: 'new',
                connectWith: 'ul',
                stop: this.handleStop
            });

            this.$el.append($element);

            this.model.get('components').each(this.renderChild, this);

            return this;
        },

        renderChild: function (component) {
            this.assign(new ComponentView({ model: component, isChild: true }), this.$container);
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
