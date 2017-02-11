import React from 'react';
import ComponentType from './ComponentType';
import Accordian from '../Accordian';

const styles = {
    caption: {
        textTransform: 'uppercase',
        color: '#fff',
        padding: '10px'
    }
}

const Group = ({ name, componentTypes }) => (
    <Accordian caption={name} captionStyle={styles.caption}>
        {componentTypes.map((componentType, i) => <ComponentType key={i} componentType={componentType} />)}
    </Accordian>
);

export default Group;