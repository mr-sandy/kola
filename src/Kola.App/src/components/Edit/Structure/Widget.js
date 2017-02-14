import React from 'react';
import Area from './Area';
import Accordian from '../Accordian';
import { commonStyles, buildOuterStyle } from './commonStyles';

const Widget = ({ component, isSelected, isHighlighted, ...otherProps }) => (
    <Accordian outerStyle={buildOuterStyle(component.type, isSelected, isHighlighted)} 
            captionStyle={commonStyles.caption} 
            innerStyle={commonStyles.inner} caption={`${component.type}: ${component.name}`} 
            className="transition-all">
        {component.areas.map((a, i) => <Area key={i} area={a} {...otherProps} />)}
    </Accordian>
);

export default Widget;
