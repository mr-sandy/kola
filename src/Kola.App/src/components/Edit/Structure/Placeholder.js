import React from 'react';

const style = {
    height: '30px',
    borderWidth: '1px',
    borderStyle: 'dotted',
    borderColor: '#eee'
}

const Placeholder = () => (
    <div style={{ paddingTop: '8px', paddingBottom: '8px' }}>
        <div style={style}></div>
    </div>
);

export default Placeholder;
