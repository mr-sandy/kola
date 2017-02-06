import React, { Component } from 'react';

const styles = {
    outer: {
        color: '#eee',
        borderWidth: '1px',
        borderColor: '#ccc',
        borderStyle: 'solid',
        marginBottom: '8px'
    },
    caption: {
        display: 'block',
        padding: '8px'
    },
    inner: {
        padding: '8px 8px 0 8px',
        borderTopWidth: '1px',
        borderTopColor: '#ccc',
        borderTopStyle: 'solid'
    }
};

class Atom extends Component {
    render() {
        const { component } = this.props;

        return (
            <div style={this.buildOuterStyle()}
                    className="transition-all"
                    onMouseOver={e => this.handleMouseOver(e)}
                    onMouseLeave={e => this.handleMouseLeave(e)}
                    onClick={e => this.handleClick(e)}>
                <span style={styles.caption}>{component.type}: {component.name}</span>
            </div>
        );
    }
    
    buildOuterStyle() {
        const { component, selectedComponent, highlightedComponent } = this.props;

        const isSelected = component.path === selectedComponent;
        const isHighlighted = component.path === highlightedComponent;

        if (isSelected) {
            return { ...styles.outer, backgroundColor: 'rgba(178,32,40,0.4)' };
        }

        if (isHighlighted) {
            return { ...styles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return styles.outer;
    }

    handleClick(e) {
        e.stopPropagation();

        const { component, selectComponent  = () => {}} = this.props;
        selectComponent(component.path);
    }

    handleMouseOver(e) {
        e.stopPropagation();

        const { component, highlightComponent = () => {} } = this.props;
        highlightComponent(component.path)
    }

    handleMouseLeave(e) {
        e.stopPropagation();

        const { component, dehighlightComponent = () => {} } = this.props;
        dehighlightComponent(component.path)
    }
}

export default Atom;
