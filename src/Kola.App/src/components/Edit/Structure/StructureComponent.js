import React, { Component } from 'react';
import Atom from './Atom';
import Container from './Container';
import Widget from './Widget';

const componentMappings = {
    atom: Atom,
    container: Container,
    widget: Widget
}

class StructureComponent extends Component {
    render() {
        const { component, selectedComponent, highlightedComponent } = this.props;

        const selection = {
            isSelected: component.path === selectedComponent,
            isHighlighted: component.path === highlightedComponent
        }

        const handlers = {
            onClick: e => this.handleClick(e),
            onMouseOver: e => this.handleMouseOver(e),
            onMouseLeave: e => this.handleMouseLeave(e)
        };

        const TheComponent = componentMappings[component.type];

        return (<TheComponent {...this.props} {...selection} {...handlers} />);
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

export default StructureComponent;