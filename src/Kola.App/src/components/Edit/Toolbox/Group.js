import React from 'react';
import Component from './Component';
import Accordian from '../Accordian';

const styles = {
    caption: {
        textTransform: 'uppercase',
        color: '#fff',
        padding: '10px'
    }
}

const Group = ({ name, components }) => (
    <Accordian caption={name} captionStyle={styles.caption}>
        {components.map((component, i) => <Component key={i} component={component} />)}
    </Accordian>
);

export default Group;