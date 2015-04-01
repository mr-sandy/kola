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
            $('.toggle-add-component').toggleClass('selected');
        });

        $('.toggle-properties').click(function (e) {
            $('.properties').toggleClass('hidden');
            $('.toggle-properties').toggleClass('selected');
        });

        $('.accordian .accordian-header').click(function (e) {
            var $accordian = $(e.target).closest('.accordian');
            $accordian.toggleClass('collapsed');
            $accordian.find('.accordian-content').slideToggle(100);
        });

        $('.block-editor ol.components').sortable({
            placeholder: 'new',
            tolerance: 'pointer',
            connectWith: 'ol'
        });

        $('.block-editor li').mouseover(function (e) {
            e.preventDefault();
            var $self = $(e.target).closest('li');
            $self.addClass('highlighted');
        });

        $('.block-editor li').mouseout(function (e) {
            e.preventDefault();
            var $self = $(e.target).closest('li');
            $self.removeClass('highlighted');
        });

        $('.block-editor li').click(function (e) {
            var $self = $(e.target).closest('li');
            $self.toggleClass('selected');
        });

        $('.toolbar .pin').click(function (e) {
            var $self = $(e.target).closest('button');
            var $toolbar = $(e.target).closest('.toolbar');
            $self.toggleClass('selected');
            $toolbar.toggleClass('pinned');
        });
    });
})(jQuery);
