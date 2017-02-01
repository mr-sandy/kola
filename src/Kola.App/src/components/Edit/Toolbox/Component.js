import React, { Component } from 'react';

const styles ={
    normal: {
        padding: '4px',
        margin: '4px',
        borderWidth: '1px',
        borderColor: 'transparent',
        backgroundColor: '#666',
        borderStyle: 'solid',
        width: '25%',
        display: 'inline-block'
    },
    hover: {
        borderColor: '#fff'
    }};

class KolaComponent extends Component {
    state = {
        hovering: false
    }

    render() {
        const { component } = this.props;

        const style = this.state.hovering ? { ...styles.normal, ...styles.hover } : styles.normal;

        return (<li className="transition-all" style={style} onMouseEnter={() => this.toggleHover()} onMouseLeave={() => this.toggleHover()}>{component.name}</li>);
        }

    toggleHover() {
        this.setState({hovering: !this.state.hovering})
    }
}

export default KolaComponent;