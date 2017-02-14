import React from 'react';

const style = {
    height: '30px',
    borderWidth: '2px',
    borderStyle: 'dashed',
    borderColor: '#999'
}

const Placeholder = () => (
    <div style={{ paddingTop: '8px', paddingBottom: '8px' }}>
        <div style={style}></div>
    </div>
);

export default Placeholder;
