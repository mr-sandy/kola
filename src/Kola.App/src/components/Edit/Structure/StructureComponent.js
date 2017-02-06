import React, { Component } from 'react';
import Atom from './Atom';
import Container from './Container';
import Widget from './Widget';
import { DropTarget } from 'react-dnd';

const squareTarget = {
    drop(props) {
        console.log('drop!');
    }
};

function collect(connect, monitor) {
    return {
        connectDropTarget: connect.dropTarget(),
        isOver: monitor.isOver()
    };
}
class StructureComponent extends Component {
    render() {
        const { component, selectedComponent, highlightedComponent } = this.props;
        const { x, y, connectDropTarget, isOver } = this.props;

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
            return connectDropTarget(<div><Atom {...this.props} {...selection} {...handlers} /></div>);

            case 'container':
                return connectDropTarget(<div><Container {...this.props} {...selection} {...handlers} /></div>);

            case 'widget':
                return connectDropTarget(<div><Widget {...this.props} {...selection} {...handlers} /></div>);

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

export default DropTarget("COMPONENT", squareTarget, collect)(StructureComponent);