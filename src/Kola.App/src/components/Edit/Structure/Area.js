import React  from 'react';
import ComponentList from './ComponentList';

const captionStyle = {
    display: 'block',
    padding: '4px 0 8px 0'
};

const Area = ({ area, ...props }) => (
    <div>
        <span style={captionStyle}>{`area: ${area.name}`}</span>
        <ComponentList components={area.components} componentPath={area.path} {...props} />
    </div>
);

export default Area;
