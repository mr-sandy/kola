import React, { Component, PropTypes } from 'react';
import { connect } from 'react-redux';

class Preview extends Component {
    render() {
        const { url } = this.props;

        const preview = url !== ''
        ? (<iframe src={`${process.env.serviceRoot}${url}`}></iframe> )
        : false;

        return (
            <div className="preview">
                {preview}    
            </div>
        );
    }
}

Preview.PropTypes = {
    url: PropTypes.string
}

export default Preview;
