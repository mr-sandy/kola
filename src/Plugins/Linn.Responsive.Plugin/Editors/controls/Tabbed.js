define(function (require) {
    "use strict";

    var $ = require('jquery');

    /* plugin definition
    * ================== */

    var Tabbed = function (element, options) {
        var defaults = {
            defaultTab: '#grid-x'
        };

        this.$element = $(element);
        this.options = $.extend(defaults, options);

        this.initialise();
    };

    _.extend(Tabbed.prototype, {
        initialise: function () {
            var $tabs = this.$element.find('ul.tabs li a');
            var $contents = this.$element.find('.tab-contents > *');

            var $defaultTab = $tabs.filter('[href=' + this.options.defaultTab + ']').first() || $tabs.first();

            $defaultTab.addClass('selected');
            $contents.filter($defaultTab.attr('href')).addClass('selected');

            $tabs.click(function (e) {
                e.preventDefault();

                var $tab = $(e.target);
                var href = $tab.attr('href');

                $tabs.removeClass('selected');
                $tab.addClass('selected');

                $contents.removeClass('selected');
                $contents.filter(href).addClass('selected');
            });
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.tabbed = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('tabbed')) {
                $this.data('tabbed', new Tabbed(this, options));
            };
        });
    };
});
