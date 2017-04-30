import React from 'react';
import SideBar from '../../containers/Edit/SideBar';
import Toolbars from '../../containers/Edit/Toolbars';
import Preview from '../../containers/Edit/Preview';

const style = {
    position: 'absolute',
    top: '0',
    left: '0',
    width: '100%',
    height: '100%'
};

const Edit = () => (
    <div style={style}>
        <SideBar />
        <Toolbars />
        <Preview />
    </div>
);

export default Edit;