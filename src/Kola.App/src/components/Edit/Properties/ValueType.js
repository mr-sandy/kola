import React from 'react';

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

const ValueType = ({ value, selected}) => {
    const valueType = value ? value.type : 'unset';

    if (!selected) {
        return (
            <span style={styles.label}>{valueType}</span>
        );
    } else {
        return (
            <select style={styles.select}>
                <option value="fixed">fixed</option>
                <option value="inherited">inherited</option>
                <option value="variable">variable</option>
          </select>
        );
    }
};

export default ValueType;