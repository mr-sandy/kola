import React, { Component } from 'react';
import previewBroker from '../../../previewBroker';
import { findNodes, getInnerNodes, deleteNodes, insertNodes, isWithinBody } from './helpers';

const style = {
    position: 'relative',
    overflow: 'hidden',
    height: '100%'
};

const innerStyle = {
    position: 'relative',
    overflowY: 'auto',
    height: '100%',
    width: '100%'
};

const iframeStyle = {
    margin: '0 auto',
    display: 'block',
    height: '100%',
    width: '100%',
    border: 'none'
}

class Preview extends Component {
    render() {
        const { previewUrls = [] } = this.props;

        // proxy preview requests when debugging on webpack dev server by using configured prefix '_preview'
        const prefix = process.env.NODE_ENV === 'development' ? '/_preview' : '';

        const src = previewUrls.length ? prefix + previewUrls[0] : '';

        return (
            <div style={style}>
            <div style={innerStyle}>
                <iframe seamless="seamless" 
                    style={iframeStyle} 
                    ref={iframe => this.iframe = iframe} 
                    src={src}>
                </iframe>
            </div>
        </div>
        );
    }

    componentDidMount() {
        previewBroker.subscribe(() => this.handleRefresh(), (path, html) => this.handleUpdate(path, html));
        this.iframe.onload = () => this.buildComponents();
    }

    buildComponents() {
//        this.iframe.contentDocument.getElementById('test').textContent = 'jam!';
//        this.logChildren(this.iframe.contentDocument.childNodes);
    }

    handleRefresh() {
        this.iframe.contentWindow.location.reload(true);
    }

    handleUpdate(componentPath, html) {

        const oldNodes = findNodes(this.iframe.contentDocument.childNodes, componentPath);
        const referenceNode = oldNodes[oldNodes.length - 1];

        if (isWithinBody(referenceNode)) {

            const wrapper = document.createElement('div');
            wrapper.innerHTML = html;

            const newNodes = getInnerNodes(wrapper.childNodes, componentPath);

            const toBeDeleted = getInnerNodes(oldNodes, componentPath);
            deleteNodes(toBeDeleted);

            insertNodes(newNodes, referenceNode);
        } else {
            this.handleRefresh();
        }

    }

    logChildren(children) {
        for (var i = 0; i < children.length; i++) {
            if (children[i].nodeType === 8) {
                console.log('########## yahoo!!!!: ' + children[i].nodeValue);
            } else {
                console.log(children[i].tagName);
            }
            if (children[i].childNodes) {
                this.logChildren(children[i].childNodes);
            }

        }
    }
}

export default Preview;