import { SELECT_COMPONENT, HIGHLIGHT_COMPONENT, DEHIGHLIGHT_COMPONENT } from '../actions';

const selection = (state = {}, action) => {
    switch (action.type) {
        case SELECT_COMPONENT:
        {
            const { selectedComponent, ...newState } = state;

            return (selectedComponent === action.payload) 
                ? newState
                : {
                    ...state,
                    selectedComponent: action.payload
                };
        }

        case HIGHLIGHT_COMPONENT:
        {
            const { highlightedComponent, ...newState } = state;

            return (highlightedComponent === action.payload) 
                ? state
                : {
                    ...newState,
                    highlightedComponent: action.payload
                };
        }

        case DEHIGHLIGHT_COMPONENT:
        {
            const { highlightedComponent, ...newState } = state;

            return (highlightedComponent === action.payload) 
                ? newState
                : state;
        }

        default:
            return state;
    }
}

export default selection;