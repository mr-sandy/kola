import React from 'react';
import SideBar from '../../containers/Edit/SideBar';
import Toolbox from '../../containers/Edit/Toolbox';
import Structure from '../../containers/Edit/Structure';
//import Properties from './Properties';
import Preview from '../../containers/Edit/Preview';

const styles = {
    main: {
        position: 'absolute',
        top: '0',
        left: '0',
        width: '100%',
        height: '100%'
    },
    toolbars: {
        position: 'absolute',
        marginLeft: '60px',
        height: '100%',
        overflow: 'hidden',
        zIndex: '20'
    },
    toolbarsPinned: {
        position: 'relative',
        marginLeft: '0',
        float: 'left'
    }
};

const Edit = ({ toolbarsPinned }) => {

    const toolbarsStyle = toolbarsPinned
        ? { ...styles.toolbars, ...styles.toolbarsPinned }
        : styles.toolbars;

    return (
        <div style={styles.main}>
            <SideBar />
            <div className="smaller-scrollbars" style={toolbarsStyle}>
                <Toolbox />
                <Structure />
            </div>
            <Preview />
        </div>
    );
}
export default Edit;