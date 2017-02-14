import { SHOW_PLACEHOLDER, HIDE_PLACEHOLDER } from '../../actions';

const placeholderPath = (state = '', action) => {
    switch (action.type) {
        case SHOW_PLACEHOLDER:
        {
            return action.payload;
        }

        case HIDE_PLACEHOLDER:
        {
            return '';
        }

        default:
            return state;
    }
}

export default placeholderPath;