import React, { Component } from 'react';
import ComponentList from './ComponentList';
import Accordian from '../Accordian';
import commonStyles from './commonStyles';

class Container extends Component {
    render() {
        const { component, ...otherProps } = this.props;
        const { onClick, onMouseOver, onMouseLeave } = otherProps;

        return (
            <Accordian outerStyle={this.buildOuterStyles()} 
                    captionStyle={commonStyles.caption} 
                    innerStyle={commonStyles.inner} caption={`${component.type}: ${component.name}`} 
                    className="transition-all"
                    onMouseOver={onMouseOver}
                    onMouseLeave={onMouseLeave}
                    onClick={onClick}>
                <ComponentList components={component.components} componentPath={component.path} {...otherProps} />
            </Accordian>
        );
    }

    buildOuterStyles() {
        const { isSelected, isHighlighted } = this.props;

        if (isSelected) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(32,113,178,0.4)' };
        }

        if (isHighlighted) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return commonStyles.outer;
    }
}

export default Container;
