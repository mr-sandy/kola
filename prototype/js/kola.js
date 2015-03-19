(function ($) {
    $(document).ready(function () {
        $('#hide-sidebar').click(function (e) {
            $('#sidebar').addClass('hidden');
            $('#sidebar-proxy').removeClass('hidden');
            $('#preview').addClass('fullscreen');
        });

        $('#show-sidebar').click(function (e) {
            $('#sidebar').removeClass('hidden');
            $('#sidebar-proxy').addClass('hidden');
            $('#preview').removeClass('fullscreen');

        });

        $('#toggle-toolbars').click(function (e) {
            $('#toolbars').toggleClass('hidden');
        });
    });
})(jQuery);