import React, { Component } from 'react';
import previewBroker from '../../previewBroker';

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

        // proxy preview requests when debuggin on webpack dev server by using configured prefix '_preview'
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
                previewBroker.subscribe(data => console.log('I see the data: ' + data));
                this.iframe.onload = () => this.buildComponents();
            }

    buildComponents() {
        //this.iframe.contentWindow.postMessage('success!', '*');
        this.iframe.contentDocument.getElementById('test').textContent = 'jam!';
        this.logChildren(this.iframe.contentDocument.childNodes);
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