import React from 'react';
import FixedValue from './FixedValue';
import InheritedValue from './InheritedValue';

const Value = props => {
    const { property } = props;

    const valueType = property.value 
        ? property.value.type 
        : property.selected ? 'fixed' : '';

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