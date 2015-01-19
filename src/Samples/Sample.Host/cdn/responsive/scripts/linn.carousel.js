(function ($) {

    /* plugin definition
    * ================== */

    var Carousel = function (element, options) {
        var defaults = {
            infinityScroll: false,
            slidePerPage: false,
            previewPrevious: 0,         // percentage of the carousel width
            previewNext: 0,             // percentage of the carousel width
            noPreviewsThreshold: 700,   // min carousel width in pixels where preview should be shown
            alignment: 'left',          // 'left', 'right', 'centre'
            touchThreshold: 15          // pixels
        };

        this.$element = $(element);
        this.options = $.extend(defaults, options);
        this.controller = this.$element.controller();

        this.initialise();
    };

    _.extend(Carousel.prototype, {
        initialise: function () {
            this.state = this.initialiseState();

            this.controller.register({
                content: this.$element.find('.slide'),
                updateHash: this.$element.attr('data-content-update-hash') === 'true',
                onChange: $.proxy(this.onChange, this)
            });

            this.resize();

            // set up event handlers
            $(window).on('resize', $.proxy(this.resize, this));
            //            this.$element.find('.next').on('click', $.proxy(this.nextClick, this));
            //            this.$element.find('.previous').on('click', $.proxy(this.previousClick, this));
            this.$element.on("touchstart", $.proxy(this.touchStart, this));

            this.$element.addClass('ready');
        },

        onChange: function (e) {

            if (e.item.index < this.state.slideCount) {

                var currentIndex = this.getIndex(this.state.currentSlide);

                var goRight = currentIndex < e.item.index;

                if (this.options.infinityScroll) {
                    var forceRight = (e.info || false) && e.info.direction === 'right';
                    var forceLeft = (e.info || false) && e.info.direction === 'left';

                    goRight = (goRight || forceRight) && !forceLeft;
                }

                if (goRight) {
                    this.navigateToRight(e.item.index);
                }
                else {
                    this.navigateToLeft(e.item.index);
                }
            }
        },

        initialiseState: function () {
            var widths = [];
            var slides = this.$element.find('.slide');

            // annotate each slide with its natural width and index
            _.each(slides, function (slide, index) {
                var $slide = $(slide);

                var width = $(slide).outerWidth();

                $slide.attr('data-natural-width', width);
                $slide.attr('data-index', index);

                widths.push(width);
            });

            return {
                widestSlideWidth: _.max(widths),
                currentSlide: slides.first(),
                slideCount: slides.length,
                positioner: this.$element.find('.positioner'),
                touch: {}
            };
        },

        resize: function () {
            if ($(window).width() !== this.state.windowWidth) {

                this.state.windowWidth = $(window).width();

                this.state.carouselWidth = this.$element.outerWidth();
                this.state.noPreviews = this.state.carouselWidth <= this.options.noPreviewsThreshold;

                this.resizeSlides(this.determineScale());
                this.resizePositioner();

                var activePosition = this.determineActivePosition(this.state.currentSlide);

                // clone items to populate next and previous positions for infinity scroll
                if (this.options.infinityScroll) {
                    this.populateLeft(this.state.currentSlide, activePosition);
                    this.populateRight(this.state.currentSlide, activePosition);
                }

                var offset = activePosition - this.state.currentSlide.position().left;
                this.placePositioner(offset);
            }
        },

        determineScale: function () {
            //determine the minimum allocation for previews of the next and previous slides
            var previewAllocation = 0;

            if (!this.state.noPreviews && this.options.previewPrevious > 0) {
                previewAllocation += this.options.previewPrevious;
            }

            if (!this.state.noPreviews && this.options.previewNext > 0) {
                previewAllocation += this.options.previewNext;
            }

            var availableWidth = this.state.carouselWidth * (1 - previewAllocation);

            if (this.options.slidePerPage || this.state.widestSlideWidth > availableWidth) {
                return availableWidth / this.state.widestSlideWidth;
            }
            else {
                return 1;
            }
        },

        resizeSlides: function (scale) {
            _.each(this.$element.find('.slide'), function (slide) {
                var $slide = $(slide);
                var naturalWidth = $slide.attr('data-natural-width');
                $slide.css('width', naturalWidth * scale);
            });
        },

        resizePositioner: function () {
            var oldWidth = this.state.positioner.outerWidth();
            var newWidth = _.reduce(this.$element.find('.slide'), function (width, s) { return $(s).outerWidth() + width; }, 10); // the 10 is just to accommodate rounding errors - could probably just be 1
            this.state.positioner.width(newWidth);

            //return the change in width
            return newWidth - oldWidth;
        },

        adjustPositioner: function (adjustment) {
            if (adjustment !== 0) {
                var currentPosition = this.state.positioner.position().left;
                var newPosition = currentPosition - adjustment;
                this.placePositioner(newPosition);
            }
        },

        placePositioner: function (position, animate) {
            var deferred = new $.Deferred();

            if (this.state.timeoutId) {
                window.clearTimeout(this.state.timeoutId);
            }

            if (animate) {
                // animate to the new position
                this.state.positioner.stop().animate({ 'left': position + 'px' }, 300, 'easeOutQuad', deferred.resolve);
            }
            else {
                this.state.positioner.stop().css({ 'left': position + 'px' });
                deferred.resolve();
            }

            this.state.currentPosition = position;

            return deferred;
        },

        determineActivePosition: function (slide) {
            if (this.options.alignment === 'left') {
                var isFirst = slide.prev('.slide').length === 0;

                if (!this.state.noPreviews && this.options.previewPrevious > 0 && (this.options.infinityScroll || !isFirst)) {
                    return this.state.carouselWidth * this.options.previewPrevious;
                }
                else {
                    return 0;
                }
            }
            else if (this.options.alignment === 'centre') {
                var w = slide.outerWidth();

                return (this.state.carouselWidth - w) / 2;

            }
            else if (this.options.alignment === 'right') {
                var isLast = slide.next('.slide').length === 0;

                if (!this.state.noPreviews && this.options.previewNext > 0 && (this.options.infinityScroll || !isLast)) {
                    return (this.state.carouselWidth * (1 - this.options.previewNext)) - slide.outerWidth();
                }
                else {
                    return this.state.carouselWidth - slide.outerWidth();
                }
            }
        },

        getIndex: function (slide) {
            return parseInt(slide.attr('data-index'), 10);
        },

        equivalentExists: function (slide, direction) {
            var filter = '.slide[data-index=' + this.getIndex(slide) + ']';

            if (direction === 'after') {
                return slide.nextAll(filter).length > 0;
            } else {
                return slide.prevAll(filter).length > 0;
            }
        },

        makeClone: function (index) {
            var referenceSlide = _.find(this.$element.find('.slide'), function (s) {
                return this.getIndex($(s)) === index;
            }, this);

            return $(referenceSlide).clone({ withDataAndEvents: true });
        },

        setCurrentSlide: function (slide) {
            this.state.currentSlide = slide;

            var index = slide.attr('data-index');
            this.controller.select({ index: index });
        },

        populateLeft: function (currentSlide, currentPosition) {
            var previousSlide = currentSlide.prev('.slide');

            if (previousSlide.length > 0) {

                this.populateLeft(previousSlide, currentPosition - previousSlide.outerWidth());

                if (currentPosition <= 0 && this.equivalentExists(previousSlide, 'after')) {
                    //                    var width = previousSlide.outerWidth();
                    //                    previousSlide.css('width', 0);
                    //                    this.state.positioner.css('margin-left', width);
                    previousSlide.remove();
                    this.adjustPositioner(this.resizePositioner());
                    //                    this.state.positioner.css('margin-left', 0);
                }
            }
            else if (currentPosition > 0) {

                var newSlide = this.createLeft(currentSlide);
                this.populateLeft(newSlide, currentPosition - newSlide.outerWidth());
            }
        },

        populateRight: function (currentSlide, currentPosition) {

            var nextPosition = currentPosition + currentSlide.outerWidth();
            var nextSlide = currentSlide.next('.slide');

            if (nextSlide.length > 0) {

                this.populateRight(nextSlide, nextPosition);

                if (nextPosition > this.state.carouselWidth && this.equivalentExists(nextSlide, 'before')) {
                    nextSlide.remove();
                    this.resizePositioner();
                }
            }
            else if (nextPosition < this.state.carouselWidth) {

                var newSlide = this.createRight(currentSlide);
                this.populateRight(newSlide, nextPosition);
            }
        },

        createLeft: function (slide) {
            var slideIndex = this.getIndex(slide);
            var nextIndex = (slideIndex === 0) ? this.state.slideCount - 1 : slideIndex - 1;

            slide.before(this.makeClone(nextIndex));
            this.adjustPositioner(this.resizePositioner());

            return slide.prev('.slide');
        },

        createRight: function (slide) {
            var slideIndex = this.getIndex(slide);
            var nextIndex = (slideIndex < this.state.slideCount - 1) ? slideIndex + 1 : 0;

            slide.after(this.makeClone(nextIndex));
            this.resizePositioner();

            return slide.next('.slide');
        },

        navigateToLeft: function (targetIndex) {
            var targetSlide = this.state.currentSlide;

            while (this.getIndex(targetSlide) !== targetIndex) {
                if (targetSlide.prev('.slide').length === 0) {
                    targetSlide = this.createLeft(targetSlide);
                } else {
                    targetSlide = targetSlide.prev('.slide');
                }
            }

            this.slideLeft(targetSlide);
        },

        navigateToRight: function (targetIndex) {
            var targetSlide = this.state.currentSlide;

            while (this.getIndex(targetSlide) !== targetIndex) {
                if (targetSlide.next('.slide').length === 0) {
                    targetSlide = this.createRight(targetSlide);
                } else {
                    targetSlide = targetSlide.next('.slide');
                }
            }

            this.slideRight(targetSlide);
        },

        slideLeft: function (targetSlide) {
            if (targetSlide.length > 0) {

                var targetPosition = this.determineActivePosition(targetSlide);

                if (this.options.infinityScroll) {
                    this.populateLeft(targetSlide, targetPosition);
                }

                this.setCurrentSlide(targetSlide);

                // determine the new offset that should be set on the positioner
                var offset = targetPosition - this.state.currentSlide.position().left;

                // animate to the new position then tidy up any extraneous slides
                this.placePositioner(offset, true).done($.proxy(this.tidyUp, this));
            }
        },

        slideRight: function (targetSlide) {
            if (targetSlide.length > 0) {

                var targetPosition = this.determineActivePosition(targetSlide);

                if (this.options.infinityScroll) {
                    this.populateRight(targetSlide, targetPosition);
                }

                this.setCurrentSlide(targetSlide);

                // determine the new offset that should be set on the positioner
                var offset = targetPosition - this.state.currentSlide.position().left;

                // animate to the new position then tidy up any extraneous slides
                this.placePositioner(offset, true).done($.proxy(this.tidyUp, this));
            }
        },

        touchStart: function (e) {
            if (e.originalEvent.touches.length === 1) {
                this.state.touch.lastTouchX = e.originalEvent.touches[0].clientX;

                $(document).on('touchmove', $.proxy(this.touchMove, this));
                $(document).on('touchend', $.proxy(this.touchEnd, this));
            }

            //remove the click handlers now we know we're in the land of touch
            if (!this.state.touched) {
                this.state.touched = true;

                //                this.$element.find('.next').off('click', $.proxy(this.next, this));
                //                this.$element.find('.previous').off('click', $.proxy(this.previous, this));
            }
        },

        touchMove: function (e) {
            //Check we have a touch event arg
            if (e.originalEvent.touches.length !== 1) {
                return;
            }

            var touchX = e.originalEvent.touches[0].clientX;
            var movement = this.state.touch.lastTouchX - touchX;

            if (movement && (this.state.touch.inTouch || Math.abs(movement) > this.options.touchThreshold)) {
                e.preventDefault();
                e.stopPropagation();

                this.state.touch.inTouch = true;
                this.state.touch.lastTouchX = touchX;
                this.state.touch.lastMove = movement;

                var newPosition = this.state.positioner.position().left - movement;

                // check to see if we need to add a clone to the right
                if ((newPosition + this.state.positioner.outerWidth()) < this.state.carouselWidth) {
                    var lastSlide = this.state.positioner.find('.slide:last');
                    this.createRight(lastSlide);
                }

                // check to see if we need to add a clone to the left
                if (newPosition > 0) {
                    var firstSlide = this.state.positioner.find('.slide:first');
                    this.createLeft(firstSlide);

                    // createSlide moves the positioner, so get the updated value and recalculate the new position
                    newPosition = this.state.positioner.position().left - movement;
                }

                this.placePositioner(newPosition);
            }
        },

        touchEnd: function (e) {
            var drift = this.state.touch.lastMove; // * 5;

            if (drift > 0) {
                this.driftRight(drift);

            } else if (drift < 0) {
                this.driftLeft(Math.abs(drift));
            }

            this.state.touch = {};
            $(document).off('touchmove', $.proxy(this.touchMove, this));
            $(document).off('touchend', $.proxy(this.touchEnd, this));
        },

        driftLeft: function (distance) {
            var driftedOffset = this.state.positioner.position().left + distance;

            // find the element that is within tolerance of the drifted offset
            var targetSlide = this.findToLeft(driftedOffset);

            this.setCurrentSlide(targetSlide);

            var targetPosition = this.determineActivePosition(targetSlide);

            this.populateLeft(targetSlide, targetPosition);

            // determine the new offset that should be set on the positioner
            var offset = targetPosition - this.state.currentSlide.position().left;

            // animate to the new position then tidy up any extraneous slides
            this.placePositioner(offset, true).done($.proxy(this.tidyUp, this));
        },

        findToLeft: function (targetPosition) {
            // starting at the first slide, move towards the position until 
            // you find the elenent who's leading half contains the position
            var candidate = this.state.positioner.find('.slide').first();
            var currentPosition = 0;

            var threshold = currentPosition + (candidate.outerWidth() / 2);
            while (threshold < targetPosition) {
                currentPosition += candidate.outerWidth();

                if (candidate.prev('.slide').length === 0) {
                    candidate = this.createLeft(candidate);
                } else {
                    candidate = candidate.prev('.slide');
                }
                threshold = currentPosition + (candidate.outerWidth() / 2);
            }

            return candidate;
        },

        driftRight: function (distance) {
            var driftedOffset = this.state.positioner.position().left - distance;

            //            $('#console').html(driftedOffset);

            // find the element that is within tolerance of the drifted offset
            var targetSlide = this.findToRight(driftedOffset);

            this.setCurrentSlide(targetSlide);

            var targetPosition = this.determineActivePosition(targetSlide);

            this.populateRight(targetSlide, targetPosition);

            // determine the new offset that should be set on the positioner
            var offset = targetPosition - this.state.currentSlide.position().left;

            // animate to the new position then tidy up any extraneous slides
            this.placePositioner(offset, true).done($.proxy(this.tidyUp, this));
        },

        findToRight: function (targetPosition) {
            // starting at the first slide, move towards the position until 
            // you find the elenent who's leading half contains the position
            var candidate = this.state.positioner.find('.slide').first();
            var currentPosition = 0;

            var threshold = currentPosition - (candidate.outerWidth() / 2);
            while (threshold > targetPosition) {
                currentPosition -= candidate.outerWidth();

                if (candidate.next('.slide').length === 0) {
                    candidate = this.createRight(candidate);
                } else {
                    candidate = candidate.next('.slide');
                }
                threshold = currentPosition - (candidate.outerWidth() / 2);
            }

            return candidate;
        },

        tidyUp: function () {
            var self = this;

            if (this.options.infinityScroll) {
                this.state.timeoutId = window.setTimeout(function () {
                    var targetPosition = self.determineActivePosition(self.state.currentSlide);
                    self.populateLeft(self.state.currentSlide, targetPosition);
                    self.populateRight(self.state.currentSlide, targetPosition);
                }, 500);
            }
        }


    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.carousel = function (options) {
        return this.each(function () {
            var $this = $(this);
            if (!$this.data('carousel')) {
                $this.data('carousel', new Carousel(this, options));
            };
        });
    };

    /* plugin assignment
    * ================== */
    $(window).load(function () {
        $('.carousel').each(function () {

            var $el = $(this);

            var options = {};

            options.infinityScroll = $el.attr('data-carousel-infinity-scroll') === 'true';

            options.slidePerPage = $el.attr('data-carousel-slide-per-page') === 'true';

            if ($el.attr('data-carousel-alignment')) {
                options.alignment = $el.attr('data-carousel-alignment');
            };

            if ($el.attr('data-carousel-preview-previous')) {
                options.previewPrevious = parseFloat($el.attr('data-carousel-preview-previous'));
            };

            if ($el.attr('data-carousel-preview-next')) {
                options.previewNext = parseFloat($el.attr('data-carousel-preview-next'));
            };

            if ($el.attr('data-carousel-no-previews-threshold')) {
                options.noPreviewsThreshold = parseInt($el.attr('data-carousel-no-previews-threshold'));
            };

            $el.carousel(options);
        });
    });
})(jQuery);