define(function (require) {
    "use strict";


    return {
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
                    if (childNodes && childNodes.length > 0) {
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

            return selected;
        },

        findDirectlyOwned: function (nodes) {
            var depth = 0;
            var selected = [];

            for (var i = 1; i < nodes.length - 1; i++) {
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

        replace: function ($el, data) {

            var firstOldNode = $el[0];
            var parentNode = $el[0].parentNode;
            var $data = $(data);

            //prepend the current selection with the new nodes
            for (var i = 0; i < $data.length; i++) {
                //Insert into the dom
                parentNode.insertBefore($data[i], firstOldNode);
            }

            //remove the old nodes
            $el.remove();

            //return the new nodes
            return $data;
        }
    };
});
