import React, { Component } from 'react';
import StructureComponent from './StructureComponent';
import { DropTarget } from 'react-dnd';

const target = {
    drop(props, monitor) {
        const { onDrop } = props;
        if (onDrop) {
            onDrop(monitor.getItem());
        }
    },

    hover(props, monitor, component) {
        component.setState({ placeholderIndex: 0 })
        //const { onHover } = props;
        //if (onHover) {
        //    onHover(monitor.getItem());
        //}
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
    borderColor: '#999'
}

const Placeholder = () => (
    <div style={placeholderStyle}></div>
    );

class ComponentList extends Component {
    state = {
        placeholderIndex: -1
    }

    render() {
        const { components, connectDropTarget, isOver, isOverChild, style = {}, ...otherProps } = this.props;

        let styles = style;

        //if (isOverChild) {
        //    styles = { ...styles, backgroundColor: 'blue' };
        //}

        //if (isOver) {
        //    styles = { ...styles, backgroundColor: 'rgba(255, 255, 255, 0.1)' };
        //}

        const keyed = components.map((c, i) => { return { key: i, ...c } });
        const children = this.state.placeholderIndex > -1
            ? [ ...keyed.slice(0, this.state.placeholderIndex), { placeholder: true, key: 'placeholder' }, ...keyed.slice(this.state.placeholderIndex) ]
            : keyed;

        return (
            connectDropTarget(<div style={styles}>
            { children.map((c, i) => {
                    return c.placeholder
                        ? <Placeholder key={c.key} />
                        : <StructureComponent key={c.key} component={c} {...otherProps} />;
                }) }
        </div>)
    );
        }
}

export default DropTarget('COMPONENT', target, collect)(ComponentList);