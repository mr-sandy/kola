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

const SideBar = ({ pinToolbars = () => {}, pinned }) => (
    <div style={styles.normal}>
        <div style={buttonTrayStyle}>
            <Button title="Pin Toolbars" onClick={pinToolbars} icon='fa-thumb-tack' active={pinned} />
        </div>
    </div>
);

export default SideBar;