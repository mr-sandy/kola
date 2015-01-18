define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/MaskTemplate.html');

    return Backbone.View.extend({

        template: Handlebars.compile(Template),

        initialize: function () {
            this.listenTo(this.model, 'change', this.refresh);
            this.animationSpeed = 50;
        },

        render: function () {
            this.$el.html(this.template());

            this.$el.css({
                'position': 'absolute',
                'top': 0,
                'bottom': 0,
                'left': 0,
                'right': 0
            });

            this.topMask = this.$('#topMask');
            this.bottomMask = this.$('#bottomMask');
            this.leftMask = this.$('#leftMask');
            this.rightMask = this.$('#rightMask');

            return this;
        },

        tagName: 'div',

        refresh: function () {

            var iframe = this.$el.closest('html');
            var viewHeight = iframe.outerHeight();
            var viewWidth = iframe.outerWidth();

            this.topMask.stop();
            this.topMask.animate({
                "height": this.model.get('top')
            }, this.animationSpeed);

            this.bottomMask.stop();
            this.bottomMask.animate({
                "height": viewHeight - this.model.get('bottom'),
                "top": this.model.get('bottom')
            }, this.animationSpeed);

            this.leftMask.stop();
            this.leftMask.animate({
                "height": this.model.get('bottom') - this.model.get('top'),
                "width": this.model.get('left'),
                "top": this.model.get('top')
            }, this.animationSpeed);

            this.rightMask.stop();
            this.rightMask.animate({
                "height": this.model.get('bottom') - this.model.get('top'),
                "width": viewWidth - this.model.get('right'),
                "top": this.model.get('top')
            }, this.animationSpeed);
        }
    });
});
