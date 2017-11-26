import React, { Component } from 'react';
import ValueType from './ValueType';

const styles = {
    name: {
        textTransform: 'capitalize',
        verticalAlign: 'sub'
    },
    chrome: {
        height: '18px'
    }
};

class Chrome extends Component {
    render() {
        const { property, onValueTypeChange } = this.props;
        const { selected, name, value } = property;

        return (
            <div style={styles.chrome} >
                <span style={styles.name}>{name}</span>
                <ValueType value={value} selected={selected} onChange={onValueTypeChange} />
            </div>
        );
    }
}

export default Chrome;