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

const Toolbox = ({componentTypes, showToolbox, ...props}) => {

    const groups = orderBy(groupBy(componentTypes, componentType => componentType.category), g => g.key);

    const style = showToolbox ? styles.base : { ...styles.base, width: '0' };

    return (
        <Toolbar style={style}>
            <ToolbarContent style={styles.content}>
                {groups.map(group => <Group key={group.key} name={group.key} componentTypes={group.items} {...props }/>)}
            </ToolbarContent>
            <ToolbarButtonTray>
                <Button title="Pin Toolbars" onClick={() => console.log('clicked')} icon='fa-cog' active={false} />
            </ToolbarButtonTray>
        </Toolbar>
    );
}

export default Toolbox;