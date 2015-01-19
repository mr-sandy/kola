(function ($) {

    /* plugin definition
    * ================== */

    var ContentSet = function (element, options) {
        var defaults = {
            transition: 'switch', // 'fade' or 'switch'
            speed: 200
        };

        this.$element = $(element);
        this.options = $.extend(defaults, options);
        this.controller = this.$element.controller();

        this.initialise();
    };

    _.extend(ContentSet.prototype, {

        initialise: function () {

            this.allContent = this.$element.children('[data-content-id]');
            this.fallback = this.$element.children('[data-content-set-fallback=true]');
            this.controller.register({
                content: this.allContent,
                updateHash: this.$element.attr('data-content-update-hash') === 'true',
                onChange: $.proxy(this.showSelected, this)
            });
            this.$element.addClass('ready');
        },

        showSelected: function (e) {
            this.allContent.stop(true, true);
            this.fallback.stop(true, true);

            var $target = e.item.contentId
                ? this.$element.children('[data-content-id=' + e.item.contentId + ']')
                : this.fallback;

            if ($target.length === 0) {
                $target = this.fallback;
            }

            if (!this.$current || ($target.attr('data-content-id') != this.$current.attr('data-content-id'))) {
                switch (this.options.transition) {
                    case 'fade':
                        this.doFade(this.$current, $target);
                        break;
                    default:
                        this.doSwitch(this.$current, $target);
                }

                this.$current = $target;
            }
        },

        doFade: function ($current, $target) {

            if ($current) {
                var positioning = $current.css('position');

                $current.css({ position: 'absolute', top: 0, left: 0 }).fadeOut(this.options.speed, function () {
                    $current.css('position', positioning);
                });
            }

            $target.fadeIn(this.options.speed).css('display', 'block');
        },

        doSwitch: function ($current, $target) {
            if ($current) {
                $current.hide();
            }

            $target.show().css('display', 'block');
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.contentSet = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('content-set')) {
                $this.data('content-set', new ContentSet(this, options));
            };
        });
    };

    /* plugin assignment
    * ================== */
    $(function () {
        $('.content-set').each(function () {
            var $el = $(this);
            $el.contentSet({ transition: $el.data('transition') });
        });
    });
})(jQuery);