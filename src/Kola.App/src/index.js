import React from 'react';
import { render } from 'react-dom';
import Root from './containers/Root';
import createStoreFunction from './configureStore';
import './styles.css';

const store = createStoreFunction({});

render(
    <Root store={store} />,
    document.getElementById('root')
);