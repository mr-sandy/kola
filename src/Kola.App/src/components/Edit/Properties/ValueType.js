import React, { Component } from 'react';

const styles = {
    label: {
        padding: '3px 6px',
        backgroundColor: '#666',
        color: '#ccc',
        borderRadius: '2px',
        fontFamily: 'monospace',
        fontSize: '10px',
        float: 'right'
    },
    select: {
        fontSize: '10px',
        float: 'right'
    }
};

const ValueType = ({ value, selected, onChange }) => {
    const valueType = value ? value.type : 'unset';

    return (!selected)
        ? <span style={styles.label}>{valueType}</span>
        : <select style={styles.select} onChange={e => onChange(e.target.value)} onClick={e => e.stopPropagation()}>
            <option value="fixed">fixed</option>
            <option value="inherited">inherited</option>
            <option value="variable">variable</option>
        </select>;
};

export default ValueType;