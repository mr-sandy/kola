import React from 'react';
import FixedValue from './FixedValue';
import InheritedValue from './InheritedValue';

const Value = props => {
    const { value, selected } = props;

    const valueType = value 
        ? value.type 
        : selected  ? 'fixed' : '';

    switch (valueType) {
        case 'fixed':
            return <FixedValue {...props} />;

        case 'inherited':
            return <InheritedValue {...props} />;

        default:
            return false;
    }
}

export default Value;