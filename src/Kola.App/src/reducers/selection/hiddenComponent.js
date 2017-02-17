import { HIDE_COMPONENT, UNHIDE_COMPONENT } from '../../actions';

const selectedComponent = (state = '', action) => {
    switch (action.type) {
        case HIDE_COMPONENT:
        {
            return action.payload;
        }

        case UNHIDE_COMPONENT:
        {
            return '';
        }

        default:
            return state;
    }
}

export default selectedComponent;