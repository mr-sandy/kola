import { SELECT_COMPONENT } from '../actions';

export default function template(state = {}, action) {
    switch (action.type) {
        case SELECT_COMPONENT:
            return state === action.payload.component ? {} : action.payload.component; 

        default:
            return state;
    }
}