import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';
import $ from 'jquery';

const findNodes = (node, componentPath) => {
    if (node.nodeType === 8 && node.nodeValue === (`${componentPath}-start`)) {
        const nodes = [node];
        let next = node.nextSibling;
        while (next && next.nodeType !== 8 && next.nodeValue !== (`${componentPath}-end`)) {
            nodes.push(next);
            next = next.nextSibling;
        }
        nodes.push(next);
        return nodes;
    } else {
        // this says not to use for..in  https://developer.mozilla.org/en-US/docs/Web/API/NodeList
        for (var i = 0; i < node.childNodes.length; ++i) {
            let childNode = node.childNodes[i];
            const result = findNodes(childNode, componentPath);
            if (result) {
                return result;
            }
        }
    }
}

const smallest = (a, b) => Math.min(a, b) || a || b;
const biggest = (a, b) => Math.max(a, b) || a || b;

const findBounds = nodes => nodes.reduce((coords, node) => {
    if (node && node.nodeType === 1 && $(node).is(':visible')) {
        var $node = $(node);
        var offset = $node.offset();

        return {
            top: smallest(offset.top, coords.top),
            left: smallest(offset.left, coords.left),
            bottom: biggest(offset.top + $node.outerHeight(), coords.bottom),
            right: biggest(offset.left + $node.outerWidth(), coords.right)
        }
    }
    else {
        return coords;
    }
}, {});

const findComponentPath = node => {
    if (node.nodeType === 8 && node.nodeValue.endsWith('-start')) {
        return node.nodeValue.replace('-start', '');
    } else {
        const prev = node.previousSibling;

        if (prev) {
            return findComponentPath(prev)
        }
        else {
            return findComponentPath(node.parentNode);
        }
    }
}

class Preview extends Component {

    componentDidMount() {
        this.iframe.addEventListener('load', () => this.handleLoad());
    }

    componentDidUpdate() {
        const { selectedComponent } = this.props;

        if (selectedComponent.path) {
            const nodes = findNodes(this.iframe.contentWindow.document, selectedComponent.path);
            const bounds = findBounds(nodes);
            const $body = $(this.iframe.contentWindow.document.getElementsByTagName('html'));

            if (!bounds.top) {
                this.$top.css({
                    height: 0
                });

                this.$bottom.css({
                    top: 0,
                    height: 0
                });

                this.$left.css({
                    top: 0,
                    width: 0,
                    height: 0
                });

                this.$right.css({
                    left: 0,
                    top: 0,
                    width: 0,
                    height: 0
                });
            } else {

                this.$top.css({
                    height: bounds.top + 'px'
                });

                this.$bottom.css({
                    top: bounds.bottom + 'px',
                    height: ($body.outerHeight() - bounds.bottom) + 'px'
                });

                this.$left.css({
                    top: bounds.top + 'px',
                    width: bounds.left + 'px',
                    height: (bounds.bottom - bounds.top) + 'px'
                });

                this.$right.css({
                    left: bounds.right + 'px',
                    top: bounds.top + 'px',
                    width: ($body.outerWidth() - bounds.right) + 'px',
                    height: (bounds.bottom - bounds.top) + 'px'
                });
            }
        }
    }

    render() {
        const { url } = this.props;
        const src = url !== '' ? `${process.env.serviceRoot}${url}` : '';

        return (
            <div className="preview">
                <iframe ref={el => this.iframe = el } src={src}></iframe>
            </div>
        );
    }

    handleLoad() {
        this.iframe.contentWindow.document.addEventListener('click', e => this.handleClick(e), false);

        const body = this.iframe.contentWindow.document.getElementsByTagName('body');
        body[0].insertAdjacentHTML('afterbegin', '<div id="mask" style="z-index: 9999; pointer-events: none; padding: 0; margin: 0">' +
            '<div id="top" style="position: absolute; top: 0; height: 0; left: 0; right: 0; pointer-events: none; background-color: rgba(1,1,1,0.25); padding: 0; margin: 0"></div>' +
            '<div id="bottom" style="position: absolute; height: 0; left: 0; right: 0; pointer-events: none; background-color: rgba(1,1,1,0.25); padding: 0; margin: 0"></div>' +
            '<div id="left" style="position: absolute; height: 0; width: 0; left: 0; bottom: 0; pointer-events: none; background-color: rgba(1,1,1,0.25); padding: 0; margin: 0"></div>' +
            '<div id="right" style="position: absolute; top: 0; width: 0; bottom: 0; right: 0; pointer-events: none; background-color: rgba(1,1,1,0.25); padding: 0; margin: 0"></div>' +
            '</div>');

        this.$top = $(body[0]).find('#mask #top');
        this.$bottom = $(body[0]).find('#mask #bottom');
        this.$left = $(body[0]).find('#mask #left');
        this.$right = $(body[0]).find('#mask #right');
    }

    handleClick(e) {
        const { onClick } = this.props;
        e.preventDefault();
        onClick(findComponentPath(e.target));
    }
}

Preview.PropTypes = {
    url: PropTypes.string,
    onClick: PropTypes.func.isRequired
}

export default Preview;
