define([
    'backbone',
    'handlebars',
    'app/models/Component',
    'app/models/AddComponentAmendment',
    'app/models/MoveComponentAmendment',
    'app/models/DeleteComponentAmendment',
    'app/views/ComponentView',
    'text!app/templates/RootComponentTemplate.html',
    'text!app/templates/ComponentTemplate.html'
], function (Backbone,
    Handlebars,
    Component,
    AddComponentAmendment,
    MoveComponentAmendment,
    DeleteComponentAmendment,
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

            this.model.on('change', this.render, this);
        },

        events: {
            "click .delete": "handleDelete",
        },

        render: function () {
            var $element = $(this.template(this.model.toJSON()));

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

            this.model.components.each(this.renderChild, this);

            return this;
        },

        renderChild: function (component) {
            var view = new ComponentView({ model: component, amendments: this.options.amendments });
            this.$container.append('<li class="placeholder"></li>');
            view.setElement(this.$container.find('li.placeholder')).render();
        },

        handleStop: function (event, ui) {

            if (ui.item.attr('data-type') == 'toolbox-item') {
                var amendment = new AddComponentAmendment(
                {
                    componentType: ui.item.attr('data-href'),
                    targetPath: this.combineUrls(ui.item.parent().closest('[data-component-path]').attr('data-component-path'), ui.item.index().toString())
                });
                this.options.amendments.addAmendment(amendment);
            }
            else {
                var amendment = new MoveComponentAmendment(
                {
                    sourcePath: ui.item.attr('data-component-path'),
                    targetPath: this.combineUrls(ui.item.parent().closest('[data-component-path]').attr('data-component-path'), ui.item.index().toString())
                });
                this.options.amendments.addAmendment(amendment);
            }
        },

        handleDelete: function(e){
            var amendment = new DeleteComponentAmendment({
                componentPath: $(e.target).parent().attr('data-component-path')
            });
            this.options.amendments.addAmendment(amendment);
        }
    });
});
