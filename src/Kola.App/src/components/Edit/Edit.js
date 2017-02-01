import React from 'react';
import SideBar from './SideBar';
import Toolbox from '../../containers/Edit/Toolbox';
import Structure from './Structure';
import Properties from './Properties';
import Preview from './Preview';

const styles = {
    position: 'absolute',
    top: '0',
    left: '0',
    width: '100%',
    height: '100%'
}

const drawerStyles = {
    position: 'absolute',
    marginLeft: '60px',
    height: '100%',
    overflow: 'hidden'
}

const drawerStylesPinned = {
    position: 'relative',
    marginLeft: '0',
    float: 'left',
    height: '100%',
    overflow: 'hidden'
}

const getPreviewUrls = template => {
    return template.links
        ? template.links.filter(l => l.rel === 'preview').map(l => l.href)
        : [];
}

const Edit = ({template}) => (
    <div style={styles}>
        <SideBar />
        <div style={drawerStylesPinned}>
            <Toolbox />
            <Structure components={template.components} />
            <Properties />
        </div>
        <Preview previewUrls={getPreviewUrls(template)} />
    </div>
);

export default Edit;