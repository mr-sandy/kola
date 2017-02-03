import React from 'react';

const defaultStyle = {
    float: 'left',
    height: '100%',
    backgroundColor: 'rgba(51,51,51,0.9)',
    overflow: 'hidden',
    borderLeft: '1px solid rgba(102,102,102,0.5)',
    position: 'relative'
};

const Toolbar = ({ children, style }) => (
    <div style={{ ...defaultStyle, ...style  }}>
        {children}
    </div>
);

export default Toolbar ;