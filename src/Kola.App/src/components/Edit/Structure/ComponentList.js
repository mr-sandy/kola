import React from 'react';
import { DropTarget } from 'react-dnd';
import StructureComponent from './StructureComponent';
import Placeholder from './Placeholder';
import { arraysMatch, modifySiblingPath } from './helpers';
import { toIntArray } from '../../../utility';

const style = { minHeight: '48px' };

const dropTarget = {
    drop(props, monitor) {
        if (monitor.isOver({ shallow: true })) {
            if (monitor.getItemType() === 'COMPONENT_TYPE') {
                props.onAddComponent({
                    componentPath: props.placeholderPath,
                    componentType: monitor.getItem().name
                });
            } 
            else {
                const componentPath = toIntArray(monitor.getItem().componentPath);
                props.onMoveComponent({
                    sourcePath: componentPath,
                    targetPath: modifySiblingPath(componentPath, props.placeholderPath)
                })
            }
        }
    },

    hover(props, monitor) {
        if (monitor.isOver({ shallow: true })) {
            const { componentPath, setPlaceholderPath, components } = props;
            if (components.length === 0) {
                setPlaceholderPath([...toIntArray(componentPath), 0]);
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

const insertPlaceholder = (components, componentPath, placeholderPath) => {
    if (placeholderPath.length > 0) {
        const componentPathArray = toIntArray(componentPath);
        const placeholderParent = placeholderPath.slice(0, placeholderPath.length - 1);

        if (arraysMatch(componentPathArray, placeholderParent)) {
            const placeholderIndex = placeholderPath[placeholderPath.length - 1];
            return [ ...components.slice(0, placeholderIndex), { isPlaceholder: true }, ...components.slice(placeholderIndex) ]
        }
    }

    return components;
}

const ComponentList = ({ components, componentPath, connectDropTarget, ...props }) => connectDropTarget(
        <div style={style}>
            { insertPlaceholder(components, componentPath, props.placeholderPath).map((c, i) => c.isPlaceholder
                ? <Placeholder key={i} />
                : <StructureComponent key={i} component={c} {...props} />
            ) }
        </div>
);

export default DropTarget(['COMPONENT', 'COMPONENT_TYPE'], dropTarget, dropCollect)(ComponentList);