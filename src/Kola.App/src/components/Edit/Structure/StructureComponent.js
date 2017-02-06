import React, { Component } from 'react';
import Atom from './Atom';
import Container from './Container';
import Widget from './Widget';

const styles = {
    outer: {
        color: '#eee',
        borderWidth: '1px',
        borderColor: '#ccc',
        borderStyle: 'solid',
        marginBottom: '8px'
    },
    inner: {
        padding: '8px 8px 0 8px',
        borderTopWidth: '1px',
        borderTopColor: '#ccc',
        borderTopStyle: 'solid'
    },
    caption: {
        display: 'block',
        padding: '8px'
    }
};

const selectedColours = {
    atom: 'rgba(178,32,40,0.4)',
    container: 'rgba(32,113,178,0.4)',
    widget: 'rgba(178,97,32,0.4)'
};

class StructureComponent extends Component {
    render() {
        const handlers = {
            onClick: e => this.handleClick(e),
            onMouseOver: e => this.handleMouseOver(e),
            onMouseLeave: e => this.handleMouseLeave(e)
        };

        const componentStyles = {
            captionStyle: styles.caption,
            innerStyle: styles.inner,
            outerStyle: this.buildOuterStyle()
        }

        switch (this.props.component.type) {
            case 'atom':
                return <Atom {...this.props} {...handlers} {...componentStyles} />;

            case 'container':
                return <Container {...this.props} {...handlers} {...componentStyles} />

            case 'widget':
                return <Widget {...this.props} {...handlers} {...componentStyles} />;

            default:
                return false;
        }
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

    buildOuterStyle() {
        const { component, selectedComponent, highlightedComponent } = this.props;

        const isSelected = component.path === selectedComponent;
        const isHighlighted = component.path === highlightedComponent;

        if (isSelected) {
            return { ...styles.outer, backgroundColor: selectedColours[component.type] };
        }

        if (isHighlighted) {
            return { ...styles.outer, backgroundColor: 'rgba(255,255,255,0.2)' };
        }

        return styles.outer;
    }
}

export default StructureComponent;
