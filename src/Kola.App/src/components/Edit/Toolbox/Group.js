import React from 'react';
import Component from './Component';
import Accordian from '../Accordian';

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
    <Accordian caption={name}>
        {components.map(component => <Component key={component.name} component={component} />)}
    </Accordian>
);

export default Group;