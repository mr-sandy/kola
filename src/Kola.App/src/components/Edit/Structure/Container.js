import React from 'react';
import ComponentList from './ComponentList';
import Accordian from '../Accordian';
import { commonStyles, buildOuterStyle } from './commonStyles';

const Container = ({ component, isSelected, isHighlighted, ...otherProps }) => (
    <Accordian outerStyle={buildOuterStyle(component.type, isSelected, isHighlighted)} 
                captionStyle={commonStyles.caption} 
                innerStyle={commonStyles.inner} caption={`${component.type}: ${component.name}`} 
                className="transition-all" >
        <ComponentList components={component.components} componentPath={component.path} {...otherProps} />
    </Accordian>
);

export default Container;
