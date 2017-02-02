import React, { Component } from 'react';
import classnames from 'classnames';

const styles = {
    normal:
    {
        height: '36px',
        width: '36px',
        color: '#999',
        backgroundColor: 'transparent',
        borderWidth: '2px',
        borderColor: 'transparent',
        borderStyle: 'solid'
    },
    hover:
    {
        color: '#fff',
        borderColor: '#999'
    },
    active: {
        color: '#ccc',
        backgroundColor: '#555'
    }
};

class Button extends Component {
    state = {
        hovering: false
    }

    render() {
        const { title, active, icon } = this.props;

        const hoverStyle = this.state.hovering ? { ...styles.normal, ...styles.hover } : styles.normal;
        const style = active ? { ...hoverStyle, ...styles.active } : hoverStyle;

        const classname = classnames('fa fa-lg', icon);

        return (
            <button style={style} className="transition-all" type="button" onMouseEnter={() => this.toggleHover()} onMouseLeave={() => this.toggleHover()} title={title} onClick={() => this.handleClick()}>
                <i className={classname}></i>
            </button>
        );
    }

    toggleHover() {
        this.setState({hovering: !this.state.hovering})
    }

    handleClick() {
        const { onClick } = this.props;

        if (onClick) {
            onClick();
        }
    }
}

export default Button;