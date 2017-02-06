import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import Accordian from '../Accordian';

class Container extends Component {
    render() {
        const { component, ...otherProps } = this.props;
        const { onClick, onMouseOver, onMouseLeave, outerStyle, innerStyle, captionStyle } = otherProps;

        return (
            <Accordian outerStyle={outerStyle} 
                    captionStyle={captionStyle} 
                    innerStyle={innerStyle} caption={`${component.type}: ${component.name}`} 
                    className="transition-all"
                    onMouseOver={onMouseOver}
                    onMouseLeave={onMouseLeave}
                    onClick={onClick}>
                {component.components.map((c, i) => <StructureComponent key={i} component={c} {...otherProps} />)}
            </Accordian>
        );
    }
}

export default Container;
