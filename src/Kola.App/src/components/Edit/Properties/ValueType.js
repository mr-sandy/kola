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

class ValueType extends Component {
    render() {
        const { value, selected, onChange } = this.props;

        const valueType = value ? value.type : 'unset';

        return (!selected)
            ? <span style={styles.label}>{valueType}</span>
            : <select style={styles.select} onChange={e => onChange(e.target.value)} onClick={e => e.stopPropagation()}>
                <option value="fixed" selected={valueType==='fixed'}>fixed</option>
                <option value="inherited" selected={valueType === 'inherited'}>inherited</option>
                <option value="variable" selected={valueType === 'variable'}>variable</option>
            </select>;
    }
}

export default ValueType;