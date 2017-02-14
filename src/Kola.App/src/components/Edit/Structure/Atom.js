import React from 'react';
import { commonStyles, buildOuterStyle } from './commonStyles';

const Atom = ({ component, isSelected, isHighlighted, ...otherProps }) => (
    <div style={buildOuterStyle(component.type, isSelected, isHighlighted)} className="transition-all" >
        <span style={commonStyles.caption}>{component.type}: {component.name}</span>
    </div>
);

export default Atom;
