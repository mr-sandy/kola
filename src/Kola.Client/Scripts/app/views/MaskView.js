define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var Handlebars = require('handlebars');
    var Template = require('text!app/templates/MaskTemplate.html');

    return Backbone.View.extend({

        tagName: 'div',

        containerCss: {
            'position': 'absolute',
            'top': 0,
            'bottom': 0,
            'left': 0,
            'right': 0,
            'pointer-events': 'none',
            'z-index': 999999
        },

        maskCss: {
            'position': 'absolute',
            'pointer-events': 'none',
            'z-index': 999999,
            '-webkit-transition': 'height 50ms, top 50ms, width 50ms, background-color 50ms',
            'transition': 'height 50ms, top 50ms, width 50ms, background-color 50ms'
        },

        highlightColour: 'rgba(0, 0, 0, 0.1)',

        selectedColour: 'rgba(0, 0, 0, 0.3)',

        template: Handlebars.compile(Template),

        initialize: function () {
            this.selected = null;
        },

        render: function () {
            this.$el.html(this.template());

            this.topMask = this.$('#topMask');
            this.bottomMask = this.$('#bottomMask');
            this.leftMask = this.$('#leftMask');
            this.rightMask = this.$('#rightMask');

            this.$el.css(this.containerCss);
            this.topMask.css(this.maskCss);
            this.bottomMask.css(this.maskCss);
            this.leftMask.css(this.maskCss);
            this.rightMask.css(this.maskCss);

            return this;
        },

        select: function (wysiwygComponentView) {
            this.selected = wysiwygComponentView;

            this.refresh(wysiwygComponentView)
        },

        deselect: function (wysiwygComponentView) {
            if (this.selected === wysiwygComponentView) {
                this.selected = null;
                this.refresh(wysiwygComponentView)
            }
        },

        highlight: function (wysiwygComponentView) {
            if (this.selected === null) {
                this.refresh(wysiwygComponentView)
            }
        },

        refresh: function (wysiwygComponentView) {
            var bounds = this.findBounds(wysiwygComponentView);

            var iframe = this.$el.closest('html').parent();
            var viewHeight = iframe.outerHeight();
            var viewWidth = iframe.outerWidth();

            var backgroundColour = (this.selected === null) ? this.highlightColour : this.selectedColour;

            this.topMask.css({
                'height': bounds.top,
                'background-color': backgroundColour
            });


            this.bottomMask.css({
                'height': viewHeight - bounds.bottom,
                'top': bounds.bottom,
                'background-color': backgroundColour
            });

            this.leftMask.css({
                'height': bounds.bottom - bounds.top,
                'width': bounds.left,
                'top': bounds.top,
                'background-color': backgroundColour
            });

            this.rightMask.css({
                'height': bounds.bottom - bounds.top,
                'width': viewWidth - bounds.right,
                'top': bounds.top,
                'background-color': backgroundColour
            });

            if (this.selected !== null) {
                this.scrollToContent(bounds);
            }
        },

        scrollToContent: function (bounds) {
            var body = this.$el.closest('body');
            if (body.length > 0) {
                if (bounds.top < body.scrollTop() || bounds.top > (body.scrollTop() + body.height())) {
                    var scrollTop = bounds.top - 50;
                    var boundsHeight = bounds.bottom - bounds.top;
                    if (boundsHeight < body.height()) {
                        scrollTop = bounds.top - ((body.height() - boundsHeight) / 2);
                    }
                    body.animate({ scrollTop: scrollTop }, 500);
                }
            }
        },

        findBounds: function (wysiwygComponentView, coords) {

            coords = coords || { top: null, bottom: null, left: null, right: null };

            _.each(wysiwygComponentView.$el, function (node) {
                if (node.nodeType == 1 && $(node).is(":visible")) {
                    var $node = $(node);
                    var offset = $node.offset();

                    if (offset.top < coords.top || coords.top == null) {
                        coords.top = offset.top;
                    }

                    if (offset.left < coords.left || coords.left == null) {
                        coords.left = offset.left;
                    }

                    var bottom = offset.top + $node.outerHeight();
                    if (bottom > coords.bottom || coords.bottom == null) {
                        coords.bottom = bottom;
                    }

                    var right = offset.left + $node.outerWidth();
                    if (right > coords.right || coords.right == null) {
                        coords.right = right;
                    }
                }
            });

            _.each(wysiwygComponentView.children, function (child) {
                this.findBounds(child, coords);
            }, this);

            return coords;
        }
    });
});
