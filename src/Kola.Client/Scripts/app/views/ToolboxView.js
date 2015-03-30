define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var $ = require('jquery');
    var Template = require('text!app/templates/ToolboxTemplate.html');

    require('accordian');
    require('jqueryui');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

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
});