import React, { Component } from 'react';

class Atom extends Component {
    render() {
        const { component, onClick, onMouseOver, onMouseLeave, outerStyle, captionStyle } = this.props;

        return (
            <div style={outerStyle}
                    className="transition-all"
                    onMouseOver={onMouseOver}
                    onMouseLeave={onMouseLeave}
                    onClick={onClick}>
                <span style={captionStyle}>{component.type}: {component.name}</span>
            </div>
        );
    }
}

export default Atom;
