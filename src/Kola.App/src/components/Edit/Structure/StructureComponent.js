import React, { Component } from 'react';
import Atom from './Atom';
import { findDOMNode } from 'react-dom';
import Container from './Container';
import Widget from './Widget';
import { DragSource, DropTarget } from 'react-dnd';
import flow from 'lodash/flow';
import { arraysMatch } from './helpers';
//import { doSomething } from '../../../utilities';

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
        const { component, connectDropTarget, connectDragSource, isDragging, selectedComponent, highlightedComponent } = this.props;

        const selection = {
            isSelected: component.path === selectedComponent,
            isHighlighted: component.path === highlightedComponent
        }

        const TheComponent = componentMappings[component.type];

        const style = isDragging
            ? {
                height: '0',
                opacity: '0'
            }
            : {
                paddingTop: '8px',
                paddingBottom: '8px'
            };

        return connectDragSource(connectDropTarget(
            <div onClick={e => this.handleClick(e)}
                 onMouseOver={e => this.handleMouseOver(e)}
                 onMouseLeave={e => this.handleMouseLeave(e)} 
                 style={style}>
                <TheComponent {...this.props} {...selection} />
            </div>)
        );
    }

    handleClick(e) {
        e.stopPropagation();
        this.props.selectComponent(this.props.component.path);
    }

    handleMouseOver(e) {
        e.stopPropagation();
        this.props.highlightComponent(this.props.component.path)
    }

    handleMouseLeave(e) {
        e.stopPropagation();
        this.props.unhighlightComponent(this.props.component.path)
    }
}

export default flow(
  DragSource('COMPONENT', dragSource, dragCollect),
  DropTarget(['COMPONENT', 'COMPONENT_TYPE'], dropTarget, dropCollect)
)(StructureComponent);