import { SELECT_COMPONENT, SELECT_PROPERTY } from '../../actions';

const selectedProperty = (state = '', action) => {
    switch (action.type) {
        case SELECT_PROPERTY:
        {
            return state === action.payload
                ? ''
                : action.payload;
        }

        case SELECT_COMPONENT:
        {
            return '';
        }

        default:
            return state;
    }
}

export default selectedProperty;