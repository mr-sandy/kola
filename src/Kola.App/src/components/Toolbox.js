import React from 'react';

const style = {
    backgroundColor: 'rgba(0,0,0,0.4)',
    height: '100px',
    width: '100px'
};

const Toolbox = ({components}) => {

    return (
        <div style={style}>
        <ul>
        {components.map(component => <li key={component.name}>{component.name}</li>)}
        </ul>
    </div>
    );
}

export default Toolbox;