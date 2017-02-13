import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import { DropTarget } from 'react-dnd';
import { arraysMatch } from './helpers';

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


const target = {
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

    hover(props, monitor, component) {
        if (monitor.isOver({ shallow: true })) {
            const { componentPath, setPlaceholderPath, components } = props;
            const componentPathArr = componentPath.split('/').filter(s => s).map(s => parseInt(s, 10));
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
    height: '30px',
    borderWidth: '2px',
    borderStyle: 'dashed',
    borderColor: '#999',
    marginTop: '8px',
    marginBottom: '8px'
}

const Placeholder = () => (
    <div style={placeholderStyle}></div>
    );

class ComponentList extends Component {
    render() {
        const { components, connectDropTarget, componentPath, style = { minHeight: '48px' }, ...otherProps } = this.props;
        const { placeholderPath = '' } = otherProps;

        let styles = style;
        
        let placeholderIndex = -1;
        if (placeholderPath.length > 0) {
            const componentPathArr = componentPath.split('/').filter(s => s).map(s => parseInt(s, 10));
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
                <div style={styles}>
                    { children.map((c, i) => {
                        return c.placeholder
                            ? <Placeholder key={c.key} />
                            : <StructureComponent key={c.key} component={c} {...otherProps} />;
                    }) }
                </div>);
    }
}

export default DropTarget(['COMPONENT', 'COMPONENT_TYPE'], target, collect)(ComponentList);