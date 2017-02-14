import { HIGHLIGHT_COMPONENT, UNHIGHLIGHT_COMPONENT } from '../../actions';

const highlightedComponent = (state = '', action) => {
    switch (action.type) {
        case HIGHLIGHT_COMPONENT:
        {
            return action.payload;
        }

        case UNHIGHLIGHT_COMPONENT:
        {
            return (state === action.payload) 
                ? ''
                : state;
        }

        default:
            return state;
    }
}

export default highlightedComponent;