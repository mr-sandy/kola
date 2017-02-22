import { combineReducers } from 'redux';
import { TOGGLE_PIN_TOOLBARS, TOGGLE_TOOLBOX, TOGGLE_STRUCTURE, TOGGLE_PROPERTIES } from '../actions';

const toolbarsPinned = (state = true, action)  => {
    switch (action.type) {
        case TOGGLE_PIN_TOOLBARS:
            return !state;
        default:
            return state;
    }
}

const showToolbox = (state = true, action)  => {
    switch (action.type) {
        case TOGGLE_TOOLBOX:
            return !state;
        default:
            return state;
    }
}

const showStructure = (state = true, action)  => {
    switch (action.type) {
        case TOGGLE_STRUCTURE:
            return !state;
        default:
            return state;
    }
}

const showProperties = (state = true, action)  => {
    switch (action.type) {
        case TOGGLE_PROPERTIES:
            return !state;
        default:
            return state;
    }
}

const application = combineReducers({
    toolbarsPinned,
    showToolbox,
    showStructure,
    showProperties
});

export default application;