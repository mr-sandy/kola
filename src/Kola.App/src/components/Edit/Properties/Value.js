import React from 'react';
import FixedValue from './FixedValue';

const Unset = props => {
    return <h1>Unset</h1>;
}

const Value = props => {
    switch (props.value ? props.value.type : '') {
        case 'fixed':
            return <FixedValue {...props} />;
        default:
            return <Unset {...props} />;
    }
}

export default Value;