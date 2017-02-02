import React, { Component } from 'react';
import classnames from 'classnames';

const styles = {
    caption: {
        textTransform: 'uppercase',
        color: '#fff',
        clear: 'both',
        display: 'block',
        cursor: 'pointer',
        padding: '10px',
    },
    expanded: {
        display: 'block'
    },
    collapsed: {
        marginTop: '-100%'
    },
    icon: {
        float: 'right'
    },
    iconCollapsed: {
        float: 'right',
        transform: 'rotate(-90deg)'
    }
};

class Accordian extends Component {
    state = {
        collapsed: false
    }

    render() {
        const { caption, children } = this.props;

        //const hoverStyle = this.state.hovering ? { ...styles.normal, ...styles.hover } : styles.normal;
        const containerStyle = this.state.collapsed ? styles.collapsed : styles.expanded;
        const iconStyle = this.state.collapsed ? styles.iconCollapsed : styles.icon;

        //const classname = classnames('fa fa-lg', icon);

        return (
            <div>
                <span style={styles.caption} onClick={() => this.toggleCollapsed()}>{caption}<i style={iconStyle} className="transition-all fa fa-chevron-down"></i></span>
                <div style={{overflow: 'hidden'}}>
                                <div className="transition-all-250" style={containerStyle}>
                {children}
                </div>
                </div>
            </div>
        );
                }

    toggleCollapsed() {
        this.setState({collapsed: !this.state.collapsed})
    }

    handleClick() {
        const { onClick } = this.props;

        if (onClick) {
            onClick();
        }
    }
}

export default Accordian;