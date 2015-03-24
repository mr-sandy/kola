(function($) {
    $(document).ready(function() {

        $('.show-tools').click(function (e) {
            $('.sidebar').removeClass('hidden');
            $('.toolbars').removeClass('hidden');
            $('.show-tools').addClass('hidden');
            $('.preview').removeClass('fullscreen');
        });

        $('.hide-tools').click(function (e) {
            $('.sidebar').addClass('hidden');
            $('.toolbars').addClass('hidden');
            $('.show-tools').removeClass('hidden');
            $('.preview').addClass('fullscreen');
        });

        $('.toggle-block-editor').click(function (e) {
            $('.block-editor').toggleClass('hidden');
            $('.toggle-block-editor').toggleClass('selected');
        });

        $('.toggle-add-component').click(function (e) {
            $('.toolbox').toggleClass('hidden');
            $('.block-editor').toggleClass('hidden');
            $('.toggle-add-component').toggleClass('selected');
        });
    });
})(jQuery);
