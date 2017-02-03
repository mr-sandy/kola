import React, { Component } from 'react';
import SideBar from './SideBar';
import Toolbox from '../../containers/Edit/Toolbox';
import Structure from './Structure';
//import Properties from './Properties';
import Preview from './Preview';

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

const getPreviewUrls = template => {
    return template.links
        ? template.links.filter(l => l.rel === 'preview').map(l => l.href)
        : [];
}

class Edit extends Component {
    state = {
        toolbarsPinned: true
    }

    render () {
        const { template, selectComponent, highlightComponent, highlightedComponent, selectedComponent } = this.props;
        const toolbarsStyle = this.state.toolbarsPinned ? { ...styles.toolbars, ...styles.toolbarsPinned } : styles.toolbars;

        return (
            <div style={styles.main}>
                <SideBar pinToolbars={() => this.toggleToolbarsPinned()} pinned={this.state.toolbarsPinned} />
                <div className="smaller-scrollbars" style={toolbarsStyle}>
                    <Toolbox />
                    <Structure components={template.components} selectComponent={selectComponent} highlightComponent={highlightComponent} selectedComponent={selectedComponent} highlightedComponent={highlightedComponent} />
                </div>
                <Preview previewUrls={getPreviewUrls(template)} />
            </div>
        );
    }

    toggleToolbarsPinned() {
        this.setState({toolbarsPinned: !this.state.toolbarsPinned})
    }
}

export default Edit;

//
//<Properties />
