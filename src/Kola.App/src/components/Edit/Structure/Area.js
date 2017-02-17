import React  from 'react';
import { DropTarget } from 'react-dnd';
import ComponentList from './ComponentList';
import { toIntArray } from '../../../utility';

const captionStyle = {
    display: 'block',
    padding: '4px 0 8px 0'
};

const dropTarget = {
    drop(props, monitor) {
    },

    hover(props, monitor) {
        if (monitor.isOver({ shallow: true })) {
            const { showPlaceholder, area} = props;
            if (area.components.length === 0) {
                showPlaceholder('/' + [...toIntArray(area.path), 0].join('/'));
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
    <div>
        <span style={captionStyle}>{`area: ${area.name}`}</span>
        <ComponentList components={area.components} componentPath={area.path} {...props} />
    </div>
);

export default DropTarget(['COMPONENT', 'COMPONENT_TYPE'], dropTarget, dropCollect)(Area);