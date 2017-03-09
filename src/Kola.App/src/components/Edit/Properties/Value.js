import React from 'react';
import FixedValue from './FixedValue';

const Unset = props => {
    return false;
}

const Value = props => {
    const { value, selected } = props;
    const valueType = value ? value.type : selected ? 'fixed' : '';
    switch (valueType) {
        case 'fixed':
            return <FixedValue {...props} />;
        default:
            return <Unset />;
    }
}

export default Value;