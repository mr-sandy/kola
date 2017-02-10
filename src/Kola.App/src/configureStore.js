import { createStore, applyMiddleware , compose} from 'redux';
import reducer from './reducers';
import thunkMiddleware from 'redux-thunk';
import { amendmentMiddleware } from './middleware';

const createStoreFunction = initialState => {

    const middleware = applyMiddleware(thunkMiddleware, amendmentMiddleware);

    const enhancers = window.__REDUX_DEVTOOLS_EXTENSION__
        ? compose(
            middleware,
            window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
        )
        : middleware;

    return createStore(
        reducer,
        initialState,
        enhancers
    );
}

export default createStoreFunction;
