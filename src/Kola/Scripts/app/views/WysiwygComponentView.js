define(function (require) {
    "use strict";

    var Backbone = require('backbone');
    var _ = require('underscore');

    return Backbone.View.extend({

        initialize: function (options) {
            this.model.on('sync', this.refresh, this);
            this.model.on('active', this.showActive, this);
            this.model.on('inactive', this.showInactive, this);

            var self = this;
            var myElements = $(this.directlyOwned(this.$el));

            myElements.on('mouseover', function (e) {
                e.stopPropagation();
                self.model.trigger('active');
            });

            myElements.on('mouseout', function (e) {
                e.stopPropagation();
                self.model.trigger('inactive');
            });

            _.bindAll(this, 'replaceContent');
        },

        refresh: function () {
            var self = this;
            var url = '/_kola/preview/nelly?componentPath=' + this.model.get('path');

            $.ajax({
                url: url,
                dataType: 'html'
            }).done(self.replaceContent)
        },

        render: function () {
            var self = this;
            var WysiwygComponentView = require('app/views/WysiwygComponentView');

            var children = this.model.get('components') || this.model.get('areas');

            if (children) {
                children.each(function (component) {
                    var $elements = self.findElements(self.$el, component.get('path'));

                    var wysiwygComponentView = new WysiwygComponentView({ model: component, el: $elements });

                    wysiwygComponentView.render();
                });
            }
        },

        findElements: function (nodes, componentPath) {
            var select = false;
            var selected = [];

            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];

                if (node.nodeType == 8 && node.nodeValue == componentPath + '-start') {
                    select = true;
                }

                if (select) {
                    selected.push(node);
                }
                else {
                    var childNodes = node.childNodes;
                    if (childNodes) {
                        var childResult = this.findElements(childNodes, componentPath);

                        if (childResult.length > 0) {
                            return childResult;
                        }
                    }
                }

                if (node.nodeType == 8 && node.nodeValue == componentPath + '-end') {
                    select = false;
                }
            }

            return $(selected);
        },

        replaceContent: function (data) {

            //remove all but the first and last elements (the comments) from the dom using jquery remove
            this.$el.slice(1, this.$el.length - 1).remove();

            //take a note of the opening and closing comments and their parent (we'll re-use the comment nodes - they're our hook into the existing dom)
            var openingCommentNode = this.$el[0];
            var closingCommentNode = this.$el[this.$el.length - 1];
            var parentNode = closingCommentNode.parentNode;

            //Start a new version of $el, starting with the opening comment of the old (we'll add the closing later)
            var $el2 = [openingCommentNode];

            //For each of the elements of the data (except the first and last comments - they will be unchanged and we already have nodes for those) :
            var $data = $(data).slice(1, $(data).length - 1);

            for (var i = 0; i < $data.length; i++) {
                //Insert into the dom
                parentNode.insertBefore($data[i], closingCommentNode);

                //Add to our new $el
                $el2.push($data[i]);
            }

            $el2.push(closingCommentNode);

            //Finally, replace the old $el with the new
            this.setElement($el2);

            this.render();
        },

        directlyOwned: function (nodes) {
            var depth = 0;
            var selected = [];

            for (var i = 1; i < nodes.length - 2; i++) {
                var node = nodes[i];

                if (node.nodeType == 8 && node.nodeValue.indexOf('-start') > -1) {
                    depth = depth + 1;
                }

                if (depth == 0) {
                    selected.push(node);
                }

                if (node.nodeType == 8 && node.nodeValue.indexOf('-end') > -1) {
                    depth = depth - 1;
                }
            }

            return selected;
        },

        showActive: function () {
            this.$el.css({ "background-color": "#ccc" });
        },

        showInactive: function () {
            this.$el.css({ "background-color": "transparent" });
        }
    });
});