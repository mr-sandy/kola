import React from 'react';

const style = {
    padding: '4px',
    margin: '4px',
    borderWidth: '1px',
    borderColor: '#fff',
    borderStyle: 'solid'
};

const Component = ({ component }) => {
    const children = component.areas || component.components || [];

    return (
        <div style={style}>
        <span>{component.type}: {component.name} ({component.path}) </span>
        {children.map((component, i) => <Component key={i} component={component} />) }
    </div>
    );
}

export default Component;
