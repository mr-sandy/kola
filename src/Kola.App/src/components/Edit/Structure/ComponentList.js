import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import { DropTarget } from 'react-dnd';

const arraysMatch = (arr1, arr2) => {
    if (!arr1 || !arr2) {
        return false
    }

    if (arr1.length !== arr2.length) {
        return false;
    }

    for (let i = 0; i < arr1.length; i++) {
        if (arr1[i] !== arr2[i]) {
            return false;
        }
    }

    return true;
}

const target = {
    drop(props, monitor) {
        const { onDrop, componentPath } = props;
        if (onDrop && monitor.isOver({ shallow: true })) {
            onDrop(monitor.getItem(), componentPath);
        }
    },

    hover(props, monitor, component) {
        if (monitor.isOver({ shallow: true })) {
            const { componentPath, setPlaceholderPath, components } = props;
            const componentPathArr = componentPath.split('/').filter(s => s).map(s => parseInt(s));
            if (components.length === 0) {
                setPlaceholderPath([...componentPathArr, 0]);
            }
            //component.setState({ placeholderIndex: 0 })
            //const { onHover } = props;
            //if (onHover) {
            //    onHover(monitor.getItem());
            //}
        }
    }
};

function collect(connect, monitor) {
    return {
        connectDropTarget: connect.dropTarget(),
        isOver: monitor.isOver({ shallow: true }),
        isOverChild: monitor.isOver()
    };
}

const placeholderStyle = {
    height: '50px',
    borderWidth: '2px',
    borderStyle: 'dashed',
    borderColor: '#999',
    marginTop: '0',
    marginBottom: '0'
}

const Placeholder = () => (
    <div style={placeholderStyle}></div>
    );

class ComponentList extends Component {
    render() {
        const { components, connectDropTarget, componentPath, isOver, isOverChild, style = { minHeight: '48px' }, ...otherProps } = this.props;
        const { placeholderPath = '' } = otherProps;

        let styles = style;
        
        let placeholderIndex = -1;
        if (placeholderPath.length > 0) {
            const componentPathArr = componentPath.split('/').filter(s => s).map(s => parseInt(s));
            const placeholderParent = placeholderPath.slice(0, placeholderPath.length - 1);

            if (arraysMatch(componentPathArr, placeholderParent)) {
                placeholderIndex = placeholderPath[placeholderPath.length - 1];
            }
        }

        const keyed = components.map((c, i) => { return { key: i, ...c } });
            const children = placeholderIndex > -1
            ? [ ...keyed.slice(0, placeholderIndex), { placeholder: true, key: 'placeholder' }, ...keyed.slice(placeholderIndex) ]
            : keyed;

        return connectDropTarget(
                <div style={styles}>{componentPath} {placeholderPath}
                    { children.map((c, i) => {
                        return c.placeholder
                            ? <Placeholder key={c.key} />
                            : <StructureComponent key={c.key} component={c} {...otherProps} />;
                    }) }
                </div>);
    }
}

export default DropTarget('COMPONENT', target, collect)(ComponentList);