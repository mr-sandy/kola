import React, { Component } from 'react';
import { buttonTrayStyle } from './commonStyles';

const defaultStyle = {
    ...buttonTrayStyle,
    textAlign: 'right',
    borderTop: '2px solid #333',
    backgroundColor: 'rgba(51,51,51,0.8)'
};

const ToolbarButtonTray = ({ children, style }) => (
    <div style={{ ...defaultStyle, ...style  }}>
        {children}
    </div>
);
export default ToolbarButtonTray;