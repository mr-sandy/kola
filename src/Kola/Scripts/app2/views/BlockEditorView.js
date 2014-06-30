define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var componentViewFactory = require('app2/views/ComponentViewFactory');
    var $ = require('jquery');
    require('jqueryui');
    var Template = require('text!app2/templates/BlockEditorTemplate.html');


    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function () {
            _.bindAll(this, 'handleStop');

            this.model.on('sync', this.render, this);
        },

        render: function () {
            this.$el.html(this.template());

            var $list = this.$('ul').first();

            this.model.get('components').each(function (component) {
                var childView = componentViewFactory.build(component);

                $list.append(childView.render().$el);
            });

            $list.sortable({
                opacity: 0.75,
                placeholder: 'new',
                tolerance: 'pointer',
                connectWith: 'ul',
                stop: this.handleStop
            });

//            this.$('ul').sortable({
//                opacity: 0.75,
//                placeholder: 'new',
//                tolerance: 'pointer',
//                connectWith: 'ul',
//                stop: this.handleStop
//            });

            return this;
        },

        handleStop: function (event, ui) {

            var newParent = ui.item.parent().closest('[data-component-path]');

            var targetPath = (newParent.length == 0)
                        ? '/' + ui.item.index().toString()
                        : this.combineUrls(newParent.data('component-path'), ui.item.index().toString());

            if (ui.item.hasClass('tool')) {
                var componentType = ui.item.data('href');

                this.model.amendments.addComponent(componentType, targetPath);
            }
            else {
                var sourcePath = ui.item.attr('data-component-path');

                this.model.amendments.moveComponent(sourcePath, targetPath);
            }
        }
    });
});