import { RECEIVE_COMPONENT_TYPES } from '../actions';

const componentTypes = (state = [], action) => {
    switch(action.type) {
        case RECEIVE_COMPONENT_TYPES:
            return action.payload;
        default:
            return state;
    }
}

export default componentTypes;