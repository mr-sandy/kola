import { RECEIVE_COMPONENTS } from '../actions';

const components = (state = [], action) => {
    switch(action.type) {
        case RECEIVE_COMPONENTS:
            return action.payload;
        default:
            return state;
    }
}

export default components;