(function ($) {
    $(document).ready(function () {

        $('[data-show]').click(function (e) {
            e.preventDefault();
            e.stopPropagation();

            var target = $(e.target).closest('[data-show]').attr('data-show');
            $(target).show();
        });

        $('[data-hide]').click(function (e) {
            e.preventDefault();
            e.stopPropagation();

            var target = $(e.target).closest('[data-hide]').attr('data-hide');
            $(target).hide();
        });
    });
})(jQuery);
