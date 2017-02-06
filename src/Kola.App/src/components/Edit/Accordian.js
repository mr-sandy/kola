import React, { Component } from 'react';

const styles = {
    caption: {
        clear: 'both',
        display: 'block'
    },
    icon: {
        float: 'right',
        cursor: 'pointer'
    }
};

class Accordian extends Component {
    state = {
        collapsed: false
    }

    render() {
        const {
            caption,
            children,
            outerStyle = {},
            captionStyle = {},
            innerStyle = {},
            className = '',
            onClick = () => { },
            onMouseEnter = () => { },
            onMouseLeave = () => { },
            onMouseOver = () => { }
        } = this.props;

        const extendedCaptionStyle = { ...captionStyle, ...styles.caption };

        const iconStyle = this.state.collapsed
            ? { ...styles.icon, transform: 'rotate(-90deg)' }
            : styles.icon;

        //const height = this.state.collapsed
        //    ? '0'
        //    : this.contentElement ? `${this.contentElement.scrollHeight}px` : 'auto';

        const height = this.state.collapsed
            ? '0'
            : 'auto';

        return (
            <div className={className}
                style={outerStyle}
                onClick={e => onClick(e)}
                onMouseOver={e => onMouseOver(e)}
                onMouseEnter={e => onMouseEnter(e)}
                onMouseLeave={e => onMouseLeave(e)}>
                <span style={extendedCaptionStyle}>{caption}
                    <i style={iconStyle} onClick={e => this.toggleCollapsed(e)} className="transition-all fa fa-chevron-down"></i>
                </span>
                <div className="transition-all-250" ref={el => this.contentElement = el} style={{ overflow: 'hidden', height }}>
                    <div style={innerStyle}>
                        {children}
                    </div>
                </div>
            </div>
        );
    }

    //componentDidMount() {
    //    if (this.state.collapsed) {
    //        this.contentElement.style.height = '0px';
    //    }
    //    else {
    //        this.contentElement.style.height = 'auto';
    //    }
    //}

    //componentWillUpdate() {
    //    if (this.state.collapsed) {
    //        this.contentElement.style.height = '0px';
    //    } else {
    //        this.contentElement.style.height = `${this.contentElement.scrollHeight}px`;
    //        this.contentElement.scrollHeight
    //    }
    //}

    //componentDidUpdate() {
    //    if (this.state.collapsed) {
    //        this.timeout = setTimeout(() => this.contentElement.style.height = '0px', 250);
    //    }
    //    else {
    //        this.timeout = setTimeout(() => this.contentElement.style.height = 'auto', 250);
    //    }
    //}

    toggleCollapsed(e) {
        e.stopPropagation();
        //clearTimeout(this.timeout);
        this.setState({ collapsed: !this.state.collapsed })
    }
}

export default Accordian;