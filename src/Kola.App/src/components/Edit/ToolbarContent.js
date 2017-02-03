import React  from 'react';

const defaultStyle = {
    position: 'absolute',
    top: '0',
    bottom: '60px',
    left: '0',
    right: '0',
    overflowY: 'auto'
};

const ToolbarContent = ({ children, style }) => (
    <div style={{ ...defaultStyle, ...style  }}>
        {children}
    </div>
);

export default ToolbarContent ;