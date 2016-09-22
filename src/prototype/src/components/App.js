import React, { Component } from 'react';

const App = ({routes, params, children}) => {
    return (
        <div>
            {children}
        </div>
    );
};

export default App;
