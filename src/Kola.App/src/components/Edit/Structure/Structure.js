import React from 'react';
import Component from './Component';
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

const Structure = ({ components = [], selectComponent, highlightComponent, dehighlightComponent, selectedComponent, highlightedComponent }) => (
    <Toolbar style={styles.base}>
        <ToolbarContent style={styles.content}>
            {components.map((component, i) => <Component key={i} component={component} selectComponent={selectComponent} highlightComponent={highlightComponent} dehighlightComponent={dehighlightComponent} selectedComponent={selectedComponent} highlightedComponent={highlightedComponent} />)}
        </ToolbarContent>
        <ToolbarButtonTray>
            <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
        </ToolbarButtonTray>
    </Toolbar>
);

export default Structure;
