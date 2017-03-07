import React  from 'react';
import { DropTarget } from 'react-dnd';
import ComponentList from './ComponentList';
import { modifySiblingPath } from './helpers';
import { toIntArray } from '../../../utility';

const captionStyle = {
    display: 'block',
    padding: '8px 0'
};

const innerStyle = {
    padding: '4px 8px',
    borderWidth: '1px',
    borderColor: '#777',
    borderStyle: 'dotted'
};

const dropTarget = {
    drop(props, monitor) {
        const { onAddComponent, onMoveComponent, placeholderPath } = props;

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

    hover(props, monitor) {
        if (monitor.isOver({ shallow: true })) {
            const { showPlaceholder, area} = props;
            const onlyChildComponentPath = '/' + [...toIntArray(area.path), 0].join('/');
            
            // should handle the hover if:
            // - there are no children
            // - there is only one child and it is the item currently being dragged (it will be hidden, so we need to handle the hover here)
            if (area.components.length === 0 || 
               (area.components.length === 1 &&
                monitor.getItemType() === 'COMPONENT' &&
                monitor.getItem().componentPath === onlyChildComponentPath)) {
                showPlaceholder(onlyChildComponentPath);
            }
        }
    }
};

function dropCollect(connect) {
    return {
        connectDropTarget: connect.dropTarget()
    };
}

const Area = ({ area, connectDropTarget, ...props }) => connectDropTarget(
    <div style={{ paddingBottom: '4px' }}>
        <span style={captionStyle}>{`area: ${area.name}`}</span>
        <div style={innerStyle}>
            <ComponentList components={area.components} componentPath={area.path} {...props} />
        </div>
    </div>
);

export default DropTarget(['COMPONENT', 'COMPONENT_TYPE'], dropTarget, dropCollect)(Area);