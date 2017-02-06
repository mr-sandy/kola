import React from 'react';
import StructureComponent from './StructureComponent';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';
import Button from '../Button';

const styles = {
    base: {
        width: '250px'
    },  
    content: {
        padding: '10px'
    }
}

const Structure = ({ components = [], ...otherProps }) => (
        <Toolbar style={styles.base}>
        <ToolbarContent style={styles.content}>
            {components.map((component, i) => <StructureComponent key={i} component={component} {...otherProps} />)}
        </ToolbarContent>
        <ToolbarButtonTray>
            <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
        </ToolbarButtonTray>
    </Toolbar>
);

export default Structure;
