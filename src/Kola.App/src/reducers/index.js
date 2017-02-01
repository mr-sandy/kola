import { combineReducers } from 'redux';
import { RECEIVE_COMPONENTS } from '../actions';

const something = (state = {}, action) => {
    switch(action.type) {
        case RECEIVE_COMPONENTS:
            console.log(action)
            return state;
        //    return action.payload
        //        ? {
        //            name: action.payload.name,
        //            url: action.payload.links.find(l => l.rel === 'self').href
        //        }
        //        : null;
        default:
            return state;
    }
}

const rootReducer = combineReducers({
    something
});

export default rootReducer;