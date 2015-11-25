var $ = require('jquery');
var _ = require('underscore');

/* plugin definition
* ================== */

var Accordian = function (element, options) {
    var defaults = {};

    this.$element = $(element);
    this.options = $.extend(defaults, options);

    this.initialise();
};

_.extend(Accordian.prototype, {

    initialise: function () {
        var $header = this.$element.find('.accordian-header');

        $header.on('click', $.proxy(this.toggle, this));
    },

    toggle: function () {
        this.$element.toggleClass('collapsed');
        this.$element.find('.accordian-content').slideToggle(100);
    }
});

/* jQuery plugin definition
* ========================= */

$.fn.accordian = function (options) {
    return this.each(function () {
        var $this = $(this);
        if (!$this.data('accordian')) {
            $this.data('accordian', new Accordian(this, options));
        };
    });
};
