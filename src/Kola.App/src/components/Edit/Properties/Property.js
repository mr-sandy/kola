import React from 'react';
import ValueType from './ValueType';
import Button from '../Button';
import Value from './Value';

const styles = {
    outer: {
        padding: '10px 10px 0 10px',
        margin: '8px',
        borderRadius: '4px'
    },
    outerSelected: {
        padding: '10px',
        backgroundColor: '#777'
},
    name: {
        textTransform: 'capitalize',
        verticalAlign: 'sub'
    },
    chrome: {
        height: '18px'
    },
    resetButton: {
        normal: {
            borderWidth: '0',
            backgroundColor: '#ccc',
            borderRadius: '2px',
            marginTop: '8px',
            padding: '2px 6px',
            fontSize: '11px'
        },
        hover: {
            backgroundColor: '#ddd'
        }
    }
};

const Property = props => {
    const { name, selected, onClick } = props;

    const outerStyle = selected ? { ...styles.outer, ...styles.outerSelected } : styles.outer;

    return (
        <div style={outerStyle} onClick={() => onClick() }>
            <div style={styles.chrome} >
                <span style={styles.name}>{name}</span>
                <ValueType {...props} />
            </div>
            <Value {...props} selected={selected} />
            { selected
                ? <Button styles={styles.resetButton} title="Reset" caption="reset" onClick={() => console.log('clicked')} />
                : false
            }
        </div>
    );
}

export default Property;