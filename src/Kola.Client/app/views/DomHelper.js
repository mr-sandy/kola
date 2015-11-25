var $ = require('jquery');

module.exports = {
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

        selected.push(nodes[0]);

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

        selected.push(nodes[nodes.length - 1]);

        return selected;
    },

    replace: function (fromNode, toNode, newNodes) {

        var parentNode = fromNode.parentNode;

        //prepend the current selection with the new nodes
        for (var i = 0; i < newNodes.length; i++) {
            //Insert into the dom
            parentNode.insertBefore(newNodes[i], fromNode);
        }

        //remove all the nodes between the old first and last nodes
        var oldNodes = this.findBetween(fromNode, toNode);
        $(oldNodes).remove();
    },

    findBetween: function (firstNode, lastNode) {

        var nodes = [firstNode];
        var node = firstNode;

        while (node = node.nextSibling) {
            nodes.push(node);

            if (node.isEqualNode(lastNode)) {
                break;
            }
        }

        return nodes;
    }
};
