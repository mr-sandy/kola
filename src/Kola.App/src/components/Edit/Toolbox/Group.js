import React from 'react';
import Component from './Component';

const styles = {
    caption: {
        textTransform: 'uppercase',
        color: '#fff'
    },
    list: {
        listStyle: 'none',
        padding: 0,
        color: '#fff'
    }
}

const Group = ({ name, components }) => (
    <div>
        <span style={styles.caption}>{name}</span>
        <ul style={styles.list}>
        {components.map(component => <Component key={component.name} component={component} />)}
        </ul>
    </div>
);

export default Group;