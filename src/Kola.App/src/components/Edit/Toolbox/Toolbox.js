import React from 'react';
import {groupBy} from '../../helpers';
import Group from './Group';

const style = {
    backgroundColor: 'rgba(0,0,0,0.6)'
};

const Toolbox = ({components}) => {

    const groups = groupBy(components, component => component.category);

    return (
        <div style={style}>
        {groups.map(group => <Group key={group.key} name={group.key} components={group.items} />)}
        </div>
    );
}

export default Toolbox;