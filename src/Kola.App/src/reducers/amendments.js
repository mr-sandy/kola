import { RECEIVE_AMENDMENT, RECEIVE_AMENDMENTS } from '../actions';

const amendments = (state = [], action) => {
    switch(action.type) {
        case RECEIVE_AMENDMENTS:
            return action.payload.amendments;

        case RECEIVE_AMENDMENT:
            return [...state, action.payload];

        default:
            return state;
    }
}

export default amendments;