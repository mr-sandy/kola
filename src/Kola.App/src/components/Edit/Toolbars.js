import React, { Component } from 'react';
import Toolbox from '../../containers/Edit/Toolbox';
import Structure from '../../containers/Edit/Structure';
import Properties from '../../containers/Edit/Properties';

const styles = {
    base: {
        position: 'absolute',
        marginLeft: '60px',
        height: '100%',
        overflow: 'hidden',
        zIndex: '20'
    },
    pinned: {
        position: 'relative',
        marginLeft: '0',
        float: 'left'
    }
};

class Toolbars extends Component {
    render() {
        const { toolbarsPinned } = this.props;

        const style = toolbarsPinned
            ? { ...styles.base, ...styles.pinned }
            : styles.base;

        return (
            <div className="smaller-scrollbars" style={style}>
                <Toolbox />
                <Structure />
                <Properties />
            </div>
        );
    }
}

export default Toolbars;