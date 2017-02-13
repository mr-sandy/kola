import React, { Component } from 'react';
import Atom from './Atom';
import { findDOMNode } from 'react-dom';
import Container from './Container';
import Widget from './Widget';
import { DragSource, DropTarget } from 'react-dnd';
import flow from 'lodash/flow';

const componentMappings = {
    atom: Atom,
    container: Container,
    widget: Widget
}

const dropTarget = {
    drop(props, monitor) {
        const { onDrop, placeholderPath } = props;
        if (onDrop && monitor.isOver({ shallow: true })) {
            if (monitor.getItemType() === 'COMPONENT_TYPE') {
                onDrop({
                        componentPath: placeholderPath,
                        componentType: monitor.getItem().name
                    }
                );
            } else {
                console.log(monitor.getItemType());
            }
        }
    },

    hover(props, monitor, reactComponent) {
        if (monitor.isOver({ shallow: true })) {
            const { component, setPlaceholderPath } = props;

            // Determine rectangle on screen
            const hoverBoundingRect = findDOMNode(reactComponent).getBoundingClientRect();

            // Get vertical middle
            const hoverMiddleY = (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2;

            // Determine mouse position
            const clientOffset = monitor.getClientOffset();

            // Get pixels to the top
            const hoverClientY = clientOffset.y - hoverBoundingRect.top;

            const componentPath = component.path.split('/').filter(s => s).map(s => parseInt(s, 10));

            // Dragging downwards
            if (hoverClientY <= hoverMiddleY) {
                setPlaceholderPath(componentPath);
            }

            // Dragging upwards
            if (hoverClientY > hoverMiddleY) {
                setPlaceholderPath([...componentPath.slice(0, componentPath.length - 1), componentPath[componentPath.length - 1] + 1]);
            }
        }
    }
};

function dropCollect(connect, monitor) {
    return {
        connectDropTarget: connect.dropTarget(),
        isOver: monitor.isOver({ shallow: true }),
        isOverChild: monitor.isOver()
    };
}

const dragSource = {
    beginDrag({componentType}) {
    return {name: 'BADGRE!'};
  }
};

function dragCollect(connect, monitor) {
  return {
    connectDragSource: connect.dragSource(),
    isDragging: monitor.isDragging()
  }
}


class StructureComponent extends Component {
    render() {
        const { component, connectDropTarget, connectDragSource, selectedComponent, highlightedComponent } = this.props;

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

        return connectDragSource(connectDropTarget(<div style={{paddingTop: '8px', paddingBottom: '8px'}}><TheComponent {...this.props} {...selection} {...handlers} /></div>));
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

        const { component, unhighlightComponent } = this.props;
        unhighlightComponent(component.path)
    }
}

export default flow(
  DragSource('COMPONENT', dragSource, dragCollect),
  DropTarget(['COMPONENT', 'COMPONENT_TYPE'], dropTarget, dropCollect)
)(StructureComponent);