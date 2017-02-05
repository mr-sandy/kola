import { combineReducers } from 'redux';
import { TOGGLE_PIN_TOOLBARS } from '../actions';

const toolbarsPinned = (state = true, action)  => {
    switch (action.type) {
        case TOGGLE_PIN_TOOLBARS:
            return !state;
        default:
            return state;
    }
}

const application = combineReducers({
    toolbarsPinned
});

export default application;