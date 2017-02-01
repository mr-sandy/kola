import { RECEIVE_TEMPLATE } from '../actions';

const template = (state = {}, action) => {
    switch(action.type) {
        case RECEIVE_TEMPLATE:
            return action.payload;
        default:
            return state;
    }
}

export default template;