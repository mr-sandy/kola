import React, { Component } from 'react';

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

        const src = previewUrls.length ? 'http://localhost:61134' + previewUrls[0] : '';

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
                this.iframe.onload = () => this.buildComponents();
            }

    buildComponents() {
        this.iframe.contentWindow.postMessage('success!', '*');
    }
}

export default Preview;