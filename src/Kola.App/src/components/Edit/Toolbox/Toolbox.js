import React from 'react';
import { groupBy, orderBy } from '../../helpers';
import Group from './Group';
import Button from '../Button';
import Toolbar from '../Toolbar';
import ToolbarContent from '../ToolbarContent';
import ToolbarButtonTray from '../ToolbarButtonTray';

const styles = {
    base: {
        width: '242px'
    },  
    content: {
        padding: '10px'
    }
}

const Toolbox = ({components}) => {

    const groups = orderBy(groupBy(components, component => component.category), g => g.key);

    return (
        <Toolbar style={styles.base}>
            <ToolbarContent style={styles.content}>
                {groups.map(group => <Group key={group.key} name={group.key} components={group.items} />)}
            </ToolbarContent>
            <ToolbarButtonTray>
                <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
            </ToolbarButtonTray>
        </Toolbar>
    );
}

export default Toolbox;