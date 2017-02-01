import React from 'react';
import Component from './Component';

const style = {
    color: '#fff',
    backgroundColor: 'rgba(0,0,0,0.6)',
    padding: '4px'
};

const Structure = ({ components = [] }) => (
    <div style={style}>
        {components.map((component, i) => <Component key={i} component={component} />)}
    </div>
);

export default Structure;
