import React, { Component } from 'react';
import commonStyles from './commonStyles';

class Atom extends Component {
    render() {
        const { component } = this.props;

        return (
            <div style={this.buildOuterStyles()} className="transition-all" >
                <span style={commonStyles.caption}>{component.type}: {component.name}</span>
            </div>
        );
    }

    buildOuterStyles() {
        const { isSelected, isHighlighted } = this.props;

        if (isSelected) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(178,32,40,0.4)' };
        }

        if (isHighlighted) {
            return { ...commonStyles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return commonStyles.outer;
    }
}

export default Atom;
