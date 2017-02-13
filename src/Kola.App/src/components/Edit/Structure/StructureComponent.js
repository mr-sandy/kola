import React, { Component } from 'react';
import Atom from './Atom';
import { findDOMNode } from 'react-dom';
import Container from './Container';
import Widget from './Widget';
import { DragSource, DropTarget } from 'react-dnd';
import flow from 'lodash/flow';
import { arraysMatch } from './helpers';

const componentMappings = {
    atom: Atom,
    container: Container,
    widget: Widget
}

const modifyTargetPath = (sourcePath, targetPath) =>
{
    if (sourcePath.length !== targetPath.length) {
        return targetPath;
    }

    const sourceWithoutLast = sourcePath.slice(0, sourcePath.length - 1);
    const targetWithoutLast = targetPath.slice(0, targetPath.length - 1);

    if (!arraysMatch(sourceWithoutLast, targetWithoutLast)) {
        return targetPath;
    }

    const lastSource = sourcePath[sourcePath.length - 1];
    const lastTarget = targetPath[targetPath.length - 1];

    var newLast = lastSource < lastTarget
        ? lastTarget - 1
        : lastTarget;

    return [...sourceWithoutLast, newLast]
}

const dropTarget = {
    drop(props, monitor) {
        if (monitor.isOver({ shallow: true })) {
            if (monitor.getItemType() === 'COMPONENT_TYPE') {
                props.onAddComponent({
                        componentPath: props.placeholderPath,
                        componentType: monitor.getItem().name
                    }
                );
            } else {
                props.onMoveComponent({
                    sourcePath: monitor.getItem().componentPath,
                    targetPath: modifyTargetPath(monitor.getItem().componentPath, props.placeholderPath)
                })
            }
        }
    },

    hover(props, monitor, reactComponent) {
        if (monitor.isOver({ shallow: true })) {
            const { component, setPlaceholderPath } = props;

            const componentPath = component.path.split('/').filter(s => s).map(s => parseInt(s, 10));

            // Determine rectangle on screen
            const hoverBoundingRect = findDOMNode(reactComponent).getBoundingClientRect();

            // Get vertical middle
            const hoverMiddleY = (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2;

            // Determine mouse position
            const clientOffset = monitor.getClientOffset();

            // Get pixels to the top
            const hoverClientY = clientOffset.y - hoverBoundingRect.top;

            let newPlaceholderPath = [];

            // Dragging downwards
            if (hoverClientY <= hoverMiddleY) {
                newPlaceholderPath = componentPath;
            }

            // Dragging upwards
            if (hoverClientY > hoverMiddleY) {
                newPlaceholderPath = [
                    ...componentPath.slice(0, componentPath.length - 1), componentPath[componentPath.length - 1] + 1
                ];
            }

            if (monitor.getItemType() === 'COMPONENT') {
                const sourceComponentPath = monitor.getItem().componentPath;
                const modified = modifyTargetPath(sourceComponentPath, newPlaceholderPath);
                if (arraysMatch(modified, sourceComponentPath)) {
                    newPlaceholderPath = [];
                }
            }

            setPlaceholderPath(newPlaceholderPath);

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
    beginDrag({component}) {
    return { componentPath: component.path.split('/').filter(s => s).map(s => parseInt(s, 10)) };
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
        const { component, connectDropTarget, connectDragSource, isDragging, placeholderPath, isMoving, selectedComponent, highlightedComponent } = this.props;

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

        const style = isDragging
            ? {
                paddingTop: '8px',
                paddingBottom: '8px',
                opacity: '0.2'
            }
            : {
                paddingTop: '8px',
                paddingBottom: '8px'
            };

        return connectDragSource(connectDropTarget(
            <div {...handlers} style={style}>
                <TheComponent {...this.props} {...selection} />
            </div>)
        );
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