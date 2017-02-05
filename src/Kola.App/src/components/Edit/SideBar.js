import React from 'react';
import Button from './Button';
import { buttonTrayStyle }  from './commonStyles';

const styles = {
    normal: {
        position: 'relative',
        height: '100%',
        width: '60px',
        backgroundColor: '#333',
        color: '#eee',
        float: 'left',
        zIndex: '30'
    }
};

const SideBar = ({ togglePinToolbars = () => {}, toolbarsPinned }) => (
    <div style={styles.normal}>
        <div style={buttonTrayStyle}>
            <Button title="Pin Toolbars" onClick={togglePinToolbars} icon='fa-thumb-tack' active={toolbarsPinned} />
        </div>
    </div>
);

export default SideBar;