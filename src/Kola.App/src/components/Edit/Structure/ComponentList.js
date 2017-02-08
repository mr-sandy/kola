import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import { DropTarget } from 'react-dnd';

const squareTarget = {
    drop(props) {
        console.log('drop!');
    }
};

function collect(connect, monitor) {
    return {
        connectDropTarget: connect.dropTarget(),
        isOver: monitor.isOver({ shallow: true }),
        isOverChild: monitor.isOver()
};
}

class ComponentList extends Component {
    render() {
        const { components, connectDropTarget, isOver, isOverChild, ...otherProps } = this.props;

        let style = {};

        if (isOverChild) {
            style = { backgroundColor: 'blue' };
        }

        if (isOver) {
            style = { backgroundColor: 'red' };
        }

        return (
            connectDropTarget(<div style={style}>
                {components.map((c, i) => <StructureComponent key={i} component={c} {...otherProps} />)}
            </div>)
        );
    }
}

export default DropTarget('COMPONENT', squareTarget, collect)(ComponentList);