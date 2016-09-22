import { createStore, applyMiddleware } from 'redux';

import reducer from './reducers';
import thunkMiddleware from 'redux-thunk';

const createKolaStore = (initialState) => createStore(
    reducer,
    initialState,
    applyMiddleware(thunkMiddleware)
);

export default createKolaStore;