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
    },
    label: {
        normal: {
            display: 'block',
            textAlign: 'center',
            padding: '18px 0',
            color: '#eee'
        },
        inactive: {
            display: 'block',
            textAlign: 'center',
            padding: '18px 0',
            color: '#555'
        }
    },
    button: {
        normal:
        {
            border: 'none',
            padding: '18px 0',
            color: '#eee',
            backgroundColor: '#333',
            width: '100%'
        },
        hover:
        {
            color: '#fff',
            backgroundColor: '#555'
        },
        active: {
        
        },
        disabled: {
            color: '#555'
        }
    },
    bigButton: {
        normal:
        {
            marginTop: '8px',
            border: 'none',
            padding: '2px 0 0 0',
            color: '#eee',
            backgroundColor: '#789',
            borderRadius: '4px',
            width: '44px',
            height: '44px'
        },
        hover:
        {
            color: '#fff',
            backgroundColor: '#9fabb7'
        },
        active: {
            backgroundColor: '#20b2aa'
        },
        disabled: {
            color: '#555'
        }
    }
};

const SideBar = ({ togglePinToolbars, toggleToolbox, toggleStructure, showToolbox, showStructure, showProperties, toggleProperties, toolbarsPinned, amendments, saveAmendments, undoAmendment }) => (
    <div style={styles.normal}>
        <div style={{textAlign: 'center'}}>
            <Button styles={styles.bigButton} title="Toggle Toolbox" active={showToolbox} onClick={toggleToolbox} icon="fa-plus-square fa-2x" />
            <Button styles={styles.bigButton} title="Toggle Structure" active={showStructure} onClick={toggleStructure} icon="fa-th-large fa-2x" />
            <Button styles={styles.bigButton} title="Toggle Properties" active={showProperties} onClick={toggleProperties} icon="fa-table fa-2x" />
        </div>
        <div>
            <Button styles={styles.button} title="Save" enabled={amendments.length > 0} onClick={saveAmendments} icon="fa-save" />
            <Button styles={styles.button} title="Undo" enabled={amendments.length > 0} onClick={undoAmendment} icon="fa-undo" />
            <span style={amendments.length > 0 ? styles.label.normal : styles.label.inactive}>{amendments.length}</span>
        </div>
        <div style={buttonTrayStyle}>
            <Button title="Pin Toolbars" onClick={togglePinToolbars} icon="fa-thumb-tack" active={toolbarsPinned} />
        </div>
    </div>
);

export default SideBar;