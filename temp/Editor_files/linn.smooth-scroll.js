(function ($) {
    $(document).ready(function () {

        var doSmoothScroll = function (event) {
            var targetId = $(this).attr("href");
            var target = $(targetId);

            if (target && target.length > 0) {
                event.stopPropagation();

                $('body,html').stop().animate({
                    scrollTop: target.offset().top
                }, 800, function () {
                    location.hash = targetId;
                });

                return false;
            }

        };

        var hasValidTarget = function (event) {
            return $(this).attr("href") != "#";
        };

        //$('a[href^=#].button:not(.content-switch)').filter(hasValidTarget).click(doSmoothScroll);
        $('a[href^=#]').filter(hasValidTarget).click(doSmoothScroll);
    });
})(jQuery);
