import React, { Component } from 'react';
import Area from './Area';
import Accordian from '../Accordian';
import commonStyles from './commonStyles';

class Widget extends Component {
    render() {
        const { component, ...otherProps } = this.props;

        return (
            <Accordian outerStyle={this.buildOuterStyles()} 
                    captionStyle={commonStyles.caption} 
                    innerStyle={commonStyles.inner} caption={`${component.type}: ${component.name}`} 
                    className="transition-all">
                {component.areas.map((a, i) => <Area key={i} area={a} {...otherProps} />)}
            </Accordian>
        );
    }

    buildOuterStyles() {
        const { isSelected, isHighlighted } = this.props;

        if (isSelected) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(178,97,32,0.4)' };
        }

        if (isHighlighted) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return commonStyles.outer;
    }
}

export default Widget;
