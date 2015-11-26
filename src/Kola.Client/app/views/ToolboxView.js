var Backbone = require('backbone');
var $ = require('jquery');
var template = require('app/templates/ToolboxTemplate.hbs');

require('app/controls/accordian');
require('jquery-ui-bundle');

module.exports = Backbone.View.extend({

    template: template,

    initialize: function (options) {
        this.uiStateDispatcher = options.uiStateDispatcher;
        this.uiStateDispatcher.on('toggle-toolbox', this.toggleHidden, this);
    },

    render: function () {
        var context = this.collection.toJSON();
        this.$el.html(this.template(context));

        this.$('.accordian').accordian();

        this.$(".tool").draggable(
        {
            cancel: false,
            opacity: 0.7,
            iframeFix: true,
            scroll: false,
            connectToSortable: '.block-editor-root',
            helper: function () {
                return $('<li class="tool" data-href="' + $(this).attr('data-href') + '" style="list-style:none;display:inline-block;width:70px;height:70px;background-color:#999;color:#eee;border:1px solid #eee;text-align:center;padding-top:30px"></li>').text($(this).text());
            }
        });

        return this;
    },

    toggleHidden: function () {
        this.$el.toggleClass('hidden');
    }
});