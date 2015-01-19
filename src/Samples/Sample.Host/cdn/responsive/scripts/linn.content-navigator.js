(function ($) {

    /* plugin definition
    * ================== */

    var ContentNavigator = function (element, options) {
        var defaults = {
            target: 'next'
        };

        this.$element = $(element);
        this.options = $.extend(defaults, options);
        this.controller = this.$element.controller(['.carousel']);

        this.initialise();
    };

    _.extend(ContentNavigator.prototype, {
        initialise: function () {
            this.controller.register({
                onChange: $.proxy(this.highlightSelected, this)
            });

            this.$element.click($.proxy(this.handleClick, this));
        },

        highlightSelected: function (e) {
            if (e.disposition == this.options.target) {
                this.$element.addClass('selected');
            }
            else {
                this.$element.removeClass('selected');
            }

            if ((e.disposition == 'last' && this.options.target == 'next') || (e.disposition == 'first' && this.options.target == 'previous')) {
                this.$element.addClass('disabled');
            }
            else {
                this.$element.removeClass('disabled');
            }
        },

        handleClick: function (e) {
            e.preventDefault();

            this.controller.navigate(this.options.target);
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.contentNavigator = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('contentNavigator')) {
                $this.data('contentNavigator', new ContentNavigator(this, options));
            };
        });
    };

    /* plugin assignment
    * ================== */
    $(function () {
        $('.content-navigator').each(function () {

            var $el = $(this);

            var options = {};

            if ($el.attr('data-content-navigator-target')) {
                options.target = $el.attr('data-content-navigator-target');
            };

            $el.contentNavigator(options);
        });
    });
})(jQuery);