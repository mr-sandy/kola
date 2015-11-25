var Backbone = require('backbone');
var template = require('app/templates/BlockEditorTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        this.uiStateDispatcher = options.uiStateDispatcher;
        this.amendmentBroker = options.amendmentBroker;

        this.uiStateDispatcher.on('toggle-block-editor', this.toggleHidden, this);
        this.model.on('sync', this.render, this);
    },

    render: function () {
        var self = this;

        var componentViewFactory = require('app/views/ComponentViewFactory');

        this.$el.html(this.template());

        var $list = this.$('ol').first();

        this.model.get('components').each(function (component) {
            var childView = componentViewFactory.build(component, self.amendmentBroker);
            $list.append(childView.render().$el);
        });

        $list.sortable({
            opacity: 0.75,
            placeholder: 'new',
            tolerance: 'pointer',
            connectWith: 'ol',
            stop: this.amendmentBroker.handleStop
        });

        return this;
    },

    toggleHidden: function () {
        this.$el.toggleClass('hidden');
    }
});