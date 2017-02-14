import React, { Component } from 'react';
import { DragSource } from 'react-dnd';

const dragSource = {
    beginDrag({ componentType }) {
        return { name: componentType.name };
    }
};

function collect(connect, monitor) {
  return {
    connectDragSource: connect.dragSource(),
    isDragging: monitor.isDragging()
  }
}

const styles = {
    outer: {
        display: 'block',
        height: '70px',
        width: '33.3333%',
        float: 'left',
        margin: '0',
        padding: '2px'
    },
    inner: {
        display: 'flex',
        height: '100%',
        width: '100%',
        padding: '2px',
        color: '#eee',
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        borderRadius: '2px',
        borderWidth: '2px',
        borderStyle: 'solid',
        borderColor: 'transparent'
    },
    innerHover: {
        borderColor: '#ddd'
    },
    innerAtom: {
        backgroundColor: 'rgba(178,32,40,0.2)'
    },
    innerAtomHover: {
        backgroundColor: 'rgba(178,32,40,0.5)'
    },
    innerContainer: {
        backgroundColor: 'rgba(178,97,32,0.2)'
    },
    innerContainerHover: {
        backgroundColor: 'rgba(178,97,32,0.5)'
    },
    innerWidget: {
        backgroundColor: 'rgba(32,113,178,0.2)'
},
    innerWidgetHover: {
        backgroundColor: 'rgba(32,113,178,0.5)'
    }
};

class ComponentType extends Component {
    state = {
        hovering: false
    }

    render() {
        const { componentType } = this.props;
        const { connectDragSource } = this.props;

        let innerStyle = this.state.hovering ? { ...styles.inner, ...styles.innerHover } : styles.inner;
        let colourStyle;

        switch (componentType.type) {
            case 'atom':
                colourStyle = this.state.hovering ? styles.innerAtomHover : styles.innerAtom;
                break;
            case 'container':
                colourStyle = this.state.hovering ? styles.innerWidgetHover : styles.innerWidget;
                break;
            case 'widget':
                colourStyle = this.state.hovering ? styles.innerContainerHover : styles.innerContainer;
                break;
            default:
                colourStyle = {};
                break;
        }


        innerStyle = {...innerStyle, ...colourStyle }

        return connectDragSource(
            <div style={styles.outer} onMouseEnter={() => this.toggleHover()} onMouseLeave={() => this.toggleHover()}>
                <span className="transition-all" style={innerStyle}>{componentType.name}</span>
            </div>
        );
                }

    toggleHover() {
        this.setState({hovering: !this.state.hovering})
    }
}

export default DragSource('COMPONENT_TYPE', dragSource, collect)(ComponentType);