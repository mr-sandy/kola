import React, { Component } from 'react';
import { findDOMNode } from 'react-dom';
import { DragSource, DropTarget } from 'react-dnd';
import flow from 'lodash/flow';
import { modifySiblingPath, pickComponent } from './helpers';
import { toIntArray } from '../../../utility';

const styles = {
    normal: {
        paddingTop: '4px',
        paddingBottom: '4px'
    },
    dragging: {
        height: '0',
        opacity: '0'
    }
};

const dropTarget = {
    drop(props, monitor) {
        const { onAddComponent, onMoveComponent, placeholderPath = '' } = props;

        if (monitor.isOver({ shallow: true })) {
            if (monitor.getItemType() === 'COMPONENT_TYPE') {
                onAddComponent({
                    componentPath: placeholderPath,
                    componentType: monitor.getItem().name
                });
            } 
            else {
                onMoveComponent({
                    sourcePath: monitor.getItem().componentPath,
                    targetPath: modifySiblingPath(monitor.getItem().componentPath, placeholderPath)
                })
            }
        }
    },

    hover(props, monitor, reactComponent) {
        if (monitor.isOver({ shallow: true })) {
            const { component, showPlaceholder } = props;
            const hoverBoundingRect = findDOMNode(reactComponent).getBoundingClientRect();
            const hoverMiddleY = (hoverBoundingRect.bottom - hoverBoundingRect.top) / 2;
            const clientOffset = monitor.getClientOffset();
            const hoverClientY = clientOffset.y - hoverBoundingRect.top;

            if (hoverClientY <= hoverMiddleY) {
                showPlaceholder(component.path);
            }
            else if (hoverClientY > hoverMiddleY) {
                const componentPathArray = toIntArray(component.path);
                const placeholderPath = [...componentPathArray.slice(0, componentPathArray.length - 1), componentPathArray[componentPathArray.length - 1] + 1]
                showPlaceholder('/' + placeholderPath.join('/'));
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
    beginDrag({ component }) {
        return {
             componentPath: component.path
        };
    },

    isDragging({component}, monitor) {
        return component.path === monitor.getItem().componentPath;
    },

    endDrag(props) {
        props.hidePlaceholder();
    }
};

function dragCollect(connect, monitor) {
    return {
        connectDragSource: connect.dragSource(),
        isDragging: monitor.isDragging()
    };
};

class StructureComponent extends Component {
    render() {
        const { component, connectDropTarget, connectDragSource, isDragging, selectedComponent, highlightedComponent } = this.props;

        const TheComponent = pickComponent(component.type);

        return connectDragSource(connectDropTarget(
            <div onClick={e => this.handleClick(e)} 
                 onMouseOver={e => this.handleMouseOver(e)} 
                 onMouseLeave={e => this.handleMouseLeave(e)} 
                 style={isDragging ? styles.dragging : styles.normal}>
                <TheComponent isSelected={component.path === selectedComponent} 
                              isHighlighted={component.path === highlightedComponent} 
                              {...this.props} />
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