
export const findNodes = (nodes, componentPath) => {
    var select = false;
    var selected = [];

    for (let i = 0; i < nodes.length; i++) {
        const node = nodes[i];

        if (node.nodeType === 8 && node.nodeValue === componentPath + '-start') {
            select = true;
        }

        if (select) {
            selected.push(node);
        } else {
            const childNodes = node.childNodes;
            if (childNodes && childNodes.length > 0) {
                const childResult = findNodes(childNodes, componentPath);

                if (childResult.length > 0) {
                    return childResult;
                }
            }
        }

        if (node.nodeType === 8 && node.nodeValue === componentPath + '-end') {
            select = false;
        }
    }

    return selected;
};

// get the nodes between the start and end comments
export const getInnerNodes = (nodes, componentPath) => {
    const results = [];
    let startFound = false;

    // clear out the old nodes between the start and end
    for (let i = 0; i < nodes.length; i++) {
        const node = nodes[i];

        if (node.nodeType === 8 && node.nodeValue === componentPath + '-end') {
            break;
        }

        if (startFound) {
            results.push(node);
        }

        if (node.nodeType === 8 && node.nodeValue === componentPath + '-start') {
            startFound = true;
        } 
    }

    return results;
}

export const deleteNodes = nodes => {

    for (let i = 0; i < nodes.length; i++) {
        const node = nodes[i];

        node.parentNode.removeChild(node);
    }
}

export const insertNodes = (nodes, referenceNode) => {

    const parentNode = referenceNode.parentNode;

    for (let i = 0; i < nodes.length; i++) {
        const node = nodes[i];
        parentNode.insertBefore(node, referenceNode);
    }
}

export const isWithinBody = node => {
    if (node.nodeName === 'BODY') {
        return true;
    }

    var parentNode = node.parentNode;

    if (!parentNode) {
        return false;
    }

    return isWithinBody(parentNode);
}