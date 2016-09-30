import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

const findComponentPath = node => {
    if (node.nodeType === 8) {
        return node.nodeValue;
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

    componentWillReceiveProps() {

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
        this.iframe.contentWindow.document.addEventListener('click', function (evt) {
            console.log(findComponentPath(evt.target));
        }, false);
        console.log('loaded!');
    }
}

Preview.PropTypes = {
    url: PropTypes.string
}

export default Preview;
