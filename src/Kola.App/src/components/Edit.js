import React from 'react';
import SideBar from '../components/SideBar';
import ToolboxContainer from '../containers/ToolboxContainer';
import Structure from '../components/Structure';
import Properties from '../components/Properties';
import Preview from '../components/Preview';

const Edit = () => (
    <div>
        <SideBar />
        <ToolboxContainer />
        <Structure />
        <Properties />
        <Preview />
    </div>
);

export default Edit;