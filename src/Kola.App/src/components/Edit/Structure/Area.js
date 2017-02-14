import React  from 'react';
import ComponentList from './ComponentList';
import { commonStyles } from './commonStyles';

const Area = ({ area, ...props }) => (
    <div>
        <span style={commonStyles.caption}>{`area: ${area.name}`}</span>
        <ComponentList components={area.components} componentPath={area.path} {...props} />
    </div>
);

export default Area;
