(function ($) {

    /* plugin definition
    * ================== */

    var Controller = function (options) {
        var defaults = {
            contentSetId: '',
            updateHash: false
        };

        this.options = $.extend(defaults, options);
        this.initialise();
    };

    _.extend(Controller.prototype, {

        initialise: function (options) {
            this.events = $({});
            this.selectedIndex = -1;
        },

        register: function (settings) {

            if (settings.onChange) {
                this.events.on('change', settings.onChange);
            }

            if (settings.onRegister) {
                this.events.on('registered', settings.onRegister);
            }

            if (settings.updateHash) {
                this.options.updateHash = this.options.updateHash || settings.updateHash;
            }

            if (settings.content) {
                this.mappings = this.generateMappings(settings.content);
            }

            if (this.mappings && this.mappings.length > 0) {

                this.selectedIndex = this.determineSelectedIndex(settings);

                this.triggerRegistered();
                this.triggerChange();
            }
        },

        triggerChange: function (info) {

            var disposition = '';

            if (this.selectedIndex === 0) {
                disposition = 'first';
            }
            else if (this.selectedIndex === this.mappings.length - 1) {
                disposition = 'last';
            }
            else {
                disposition = this.selectedIndex;
            }

            this.events.trigger({
                type: 'change',
                disposition: disposition,
                info: info,
                item: {
                    contentId: this.mappings[this.selectedIndex],
                    index: this.selectedIndex
                }
            });
        },

        triggerRegistered: function () {
            this.events.trigger({ type: 'registered', items: this.mappings });
        },

        // Will return:
        // - the index of an item with a contentId matching the location.hash value
        // - the index of a content item decorated with 'data-default-content="true"'
        // - the implicit default (0)
        determineSelectedIndex: function (settings) {

            if (this.options.updateHash) {
                // if we've already determined the index of requested content (from the hash), return that
                if (this.requestedIndex) {
                    return this.requestedIndex;
                }

                // if there is a has value, see if we can match that
                if (location.hash) {
                    var requestedContentId = location.hash.replace("#", "");

                    var slashIndex = requestedContentId.indexOf('/');

                    if (slashIndex > -1) {
                        var contentSetId = requestedContentId.substr(0, slashIndex);

                        if (this.matchContentSetId(contentSetId)) {
                            var index = parseInt(requestedContentId.substr(slashIndex + 1));

                            if (index > -1) {
                                this.requestedIndex = index;
                                return this.requestedIndex;
                            }
                        }
                    }
                    else {
                        var requestedIndex = parseInt(_.indexOf(this.mappings, requestedContentId));
                        if (requestedIndex > -1) {
                            this.requestedIndex = requestedIndex;
                            return this.requestedIndex;
                        }
                    }
                }
            }

            // if we've already determined the index of something marked as default content (from the an attribute), return that
            if (this.defaultIndex) {
                return this.defaultIndex;
            }

            // have a look for content marked as default
            if (settings.content) {
                var index = settings.content.index($('[data-default-content="true"]'));

                if (index > -1) {
                    this.defaultIndex = index;
                    return this.defaultIndex;
                }
            }

            //return the default default 
            return 0;
        },

        matchContentSetId: function (contentSetId) {
            var thisHasValue = this.options.contentSetId && this.options.contentSetId !== '';
            var otherHasValue = contentSetId && contentSetId !== '';

            return (!thisHasValue && !otherHasValue) || (this.options.contentSetId === contentSetId);
        },

        generateMappings: function (content) {
            var newMappings = content.map(function (i, el) { return $(el).attr('data-content-id') || ''; });

            if (!this.mappings) {
                return newMappings;
            }

            return (this.mappings.length > content.length)
                ? this.mergeMappings(this.mappings, newMappings)
                : this.mergeMappings(newMappings, this.mappings);
        },

        mergeMappings: function (longer, shorter) {
            var self = this;
            var result = _.clone(longer);

            _.each(shorter, function (item, index) {
                if (item && item !== '' && !_.contains(result, item)) {
                    if (result[index] !== '' && result[index] !== item) {
                        alert('clash!' + self.options.contentSetId);
                    }
                    else {
                        result[index] = item;
                    }
                }
            });

            return result;
        },

        select: function (item, info) {

            var hasContentId = item.contentId && item.contentId !== '';
            var hasIndex = item.index > -1;

            if (hasContentId || hasIndex) {
                var index = hasIndex ? parseInt(item.index) : _.indexOf(this.mappings, item.contentId);

                if (index !== this.selectedIndex) {
                    this.selectedIndex = index;
                    this.triggerChange(info);

                    if (this.options.updateHash) {
                        var contentId = this.mappings[this.selectedIndex];
                        location.hash = contentId && contentId !== ''
                            ? contentId
                            : this.options.contentSetId + '/' + this.selectedIndex;
                    }
                }
            }
        },

        navigate: function (type) {

            if (this.mappings.length > 0) {
                switch (type) {
                    case 'first':
                        this.select({ index: 0 });
                        break;
                    case 'last':
                        this.select({ index: this.mappings.length - 1 });
                        break;
                    case 'next':
                        this.select({ index: (this.selectedIndex + 1) % this.mappings.length }, { direction: 'right' });
                        break;
                    case 'previous':
                        if (this.selectedIndex > 0) {
                            this.select({ index: this.selectedIndex - 1 }, { direction: 'left' });
                        }
                        else {
                            this.select({ index: this.mappings.length - 1 }, { direction: 'left' });
                        }
                        break;
                    default:
                        var index = parseInt(type);
                        if (index > -1 && index < this.mappings.length) {
                            this.select({ index: index });
                        }
                        break;
                }
            }
        }
    });

    /* jQuery plugin definition
    * ========================= */

    $.fn.controller = function (defaultContainers) {

        var controller = this.data('controller');
        if (!controller) {

            //find out if this element belongs to a named content set
            var contentSetId = this.attr('data-content-set-id');

            if (contentSetId) {

                var all = $('[data-content-set-id=' + contentSetId + ']');

                var existing = all.filter(function () {
                    return $(this).data('controller');
                });

                controller = (existing.length > 0) ? existing.first().controller() : new Controller({ contentSetId: contentSetId });

            }
            else {
                var containers = ['[data-content-set-id]'];

                if (defaultContainers) {
                    containers = containers.concat(defaultContainers);
                }

                var parents = this.closest(containers.join());

                controller = (parents.length > 0) ? parents.first().controller() : new Controller();
            }

            this.data('controller', controller);
        }

        return controller;
    };
})(jQuery);