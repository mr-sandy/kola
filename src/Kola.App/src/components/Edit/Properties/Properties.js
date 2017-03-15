import React from 'react';
import Button from '../Button';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Property from './Property';

const styles = {
    base: {
        color: '#eee',
        width: '242px'
    },  
    content: {
        padding: '0'
    }
}

const Properties = ({ showProperties, properties, selectProperty })=> {
    const style = showProperties ? styles.base : { ...styles.base, width: '0' };

    const handlePropertyClick = name => {
        selectProperty(name);
    }

    const handlePropertyChange = val => {
        console.log(val);
    }

    return (
        <Toolbar style={style}>
            <ToolbarContent style={styles.content}>
                { properties.map((p, i) => 
                    <Property key={i} 
                        {...p}
                        onClick={() => handlePropertyClick(p.name)} 
                        onChange={val => handlePropertyChange(val)} 
                    />) }
            </ToolbarContent>
            <ToolbarButtonTray>
                <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
            </ToolbarButtonTray>
        </Toolbar>
    );
}

export default Properties;