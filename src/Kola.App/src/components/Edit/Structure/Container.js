import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import Accordian from '../Accordian';

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

class Container extends Component {
    render() {
        const { component, ...otherProps } = this.props;
        return (
            <Accordian outerStyle={this.buildOuterStyle()} 
                            captionStyle={styles.caption} 
                            innerStyle={styles.inner} caption={`${component.type}: ${component.name}`} 
                            className="transition-all"
                            onMouseOver={e => this.handleMouseOver(e)}
                            onMouseLeave={e => this.handleMouseLeave(e)}
                            onClick={e => this.handleClick(e)}>
                {component.components.map((c, i) => <StructureComponent key={i} component={c} {...otherProps} />)}
            </Accordian>
        );
    }

    buildOuterStyle() {
        const { component, selectedComponent, highlightedComponent } = this.props;

        const isSelected = component.path === selectedComponent;
        const isHighlighted = component.path === highlightedComponent;

        if (isSelected) {
            return { ...styles.outer, backgroundColor: 'rgba(32,113,178,0.4)' };
        }

        if (isHighlighted) {
            return { ...styles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return styles.outer;
    }

    handleClick(e) {
        e.stopPropagation();

        const { component, selectComponent } = this.props;
        selectComponent(component.path);
    }

    handleMouseOver(e) {
        e.stopPropagation();

        const { component, highlightComponent } = this.props;
        highlightComponent(component.path)
    }

    handleMouseLeave(e) {
        e.stopPropagation();

        const { component, dehighlightComponent } = this.props;
        dehighlightComponent(component.path)
    }
}

export default Container;
