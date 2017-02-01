import React from 'react';

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
const Preview = ({previewUrls = []}) => {

    const src = previewUrls.length ? 'http://localhost:61134' + previewUrls[0] : '';

    return (
    <div style={style}>
        <div style={innerStyle}>
            <iframe seamless="seamless" style={iframeStyle} src={src}></iframe>
        </div>
    </div>
    );
}

export default Preview;