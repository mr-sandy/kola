import { combineReducers } from 'redux';
import { RECEIVE_COMPONENTS } from '../actions';

const components = (state = [], action) => {
    switch(action.type) {
        case RECEIVE_COMPONENTS:
            return action.payload;
        default:
            return state;
    }
}

const rootReducer = combineReducers({
    components
});

export default rootReducer;