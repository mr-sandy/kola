(function ($) {

    /* plugin definition
    * ================== */

    var Pager = function (element, options) {
        var defaults = {};

        this.$element = $(element);
        this.options = $.extend(defaults, options);
        this.controller = this.$element.controller(['.carousel']);
        this.initialise();
    };

    _.extend(Pager.prototype, {
        initialise: function () {
            this.controller.register({
                onRegister: $.proxy(this.render, this),
                onChange: $.proxy(this.highlightSelected, this)
            });
        },

        render: function (e) {

            this.$element.find('li').remove();

            for (var i = 0; i < e.items.length; i++) {
                this.$element.append('<li><a href="#" data-index="' + i + '"></a></li>');
            }

            this.$element.find('li a').click($.proxy(this.handleClick, this));

            this.$element.find('li a').first().addClass('active');
        },

        highlightSelected: function (e) {
            this.$element.find('li a').removeClass('active');
            this.$element.find('li a').eq(e.item.index).addClass('active');
        },

        handleClick: function (e) {
            e.preventDefault();

            var index = $(e.target).attr('data-index');
            this.controller.select({ index: index });
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.pager = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('pager')) {
                $this.data('pager', new Pager(this, options));
            };
        });
    };

    /* plugin assignment
    * ================== */
    $(function () {
        $('.pager').pager();
    });
})(jQuery);