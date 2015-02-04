(function ($) {

    /* plugin definition
    * ================== */

    var ContentSwitch = function (element, options) {
        var defaults = {  };

        this.$element = $(element);
        this.options = $.extend(defaults, options);
        this.controller = this.$element.controller(['.carousel']);

        this.initialise();
    };

    _.extend(ContentSwitch.prototype, {
        initialise: function () {
            this.switches = this.$element.children(':not(.not-content)');
            this.switches.click($.proxy(this.handleClick, this));

            _.each(this.switches, function (swtch, index) {
                $(swtch).attr('data-index', index);
            });

            this.controller.register({
                content: this.switches,
                updateHash: this.$element.attr('data-content-update-hash') === 'true',
                onChange: $.proxy(this.onChange, this)
            });
        },

        onChange: function (e) {
            this.switches.removeClass('selected');

            if (e.item.contentId && e.item.contentId !== '') {
                this.switches.filter('[data-target-content-id=' + e.item.contentId + ']').addClass('selected');
            }
            else if (e.item.index > -1) {
                this.switches.eq(e.item.index).addClass('selected');
            }
        },

        handleClick: function (e) {
            e.preventDefault();

            var swtch = $(e.target).closest('[data-target-content-id], [data-index]');

            if (swtch.attr('data-target-content-id')) {
                this.controller.select({ contentId: swtch.attr('data-target-content-id') });
            }
            else {
                this.controller.select({ index: swtch.attr('data-index') });
            }
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.contentSwitch = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('contentSwitch')) {
                $this.data('contentSwitch', new ContentSwitch(this, options));
            };
        });
    };

    /* plugin assignment
    * ================== */
    $(function () {
        $('.content-switch').contentSwitch();
    });
})(jQuery);