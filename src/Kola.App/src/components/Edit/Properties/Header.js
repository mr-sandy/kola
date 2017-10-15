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
        const { caption, value, selected, onValueTypeChange } = this.props;

        return (
            <div style={styles.chrome} >
                <span style={styles.name}>{caption}</span>
                <ValueType value={value} selected={selected} onChange={onValueTypeChange} />
            </div>
        );
    }
}

export default Chrome;