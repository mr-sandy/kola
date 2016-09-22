import React from 'react';
import ReactDOM from 'react-dom';
import Root from './components/Root';
import './sass/styles.scss';
import createKolaStore from './createKolaStore';

console.log('### starting ###');

const initialState = {};
const store = createKolaStore(initialState);

ReactDOM.render(<Root store={store} />, document.getElementById('root'));

// console.log('### state ###');
// console.log(store.getState());

// store.subscribe(() => {
//     console.log('### state ###');
//     console.log(store.getState());
// });