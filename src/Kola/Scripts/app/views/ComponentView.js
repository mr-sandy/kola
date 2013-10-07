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

            this.model.on('reset', function () {
                alert(this.model.get('componentPath'));
                this.render();
            }, this);
        },

        render: function (append) {
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

            if (append) {
                this.$el.append($element);
            }
            else {
                this.$el.html($element);
            }

            this.model.get('components').each(this.renderChild, this);

            return this;
        },

        renderChild: function (component) {
            //            this.assign(new ComponentView({ model: component, isChild: true }), this.$container);

            //            var html = new ComponentView({ model: component, isChild: true }).render();
            //            this.$container.append($(html).find('li'));
            //            //            var $item = this.$container.append('<li></li>');
            //            //            this.assign(new ComponentView({ model: component, isChild: true }), $item);

            var view = new ComponentView({ model: component, isChild: true });
            view.setElement(this.$container).render(true);
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
