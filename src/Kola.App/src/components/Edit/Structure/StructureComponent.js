import React, { Component } from 'react';
import Atom from './Atom';
import Container from './Container';
import Widget from './Widget';

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

        switch (this.props.component.type) {
            case 'atom':
                return <Atom {...this.props} {...selection} {...handlers} />;

            case 'container':
                return <Container {...this.props} {...selection} {...handlers} />

            case 'widget':
                return <Widget {...this.props} {...selection} {...handlers} />;

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
}

export default StructureComponent;
