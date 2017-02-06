import React from 'react';
import Atom from './Atom';
import Container from './Container';
import Widget from './Widget';

const StructureComponent = props => {
    switch (props.component.type) {
        case 'atom':
            return <Atom {...props} />;

        case 'container':
            return <Container {...props} />

        case 'widget':
            return <Widget {...props} />;

        default:
            return false;
    }
}

export default StructureComponent;
