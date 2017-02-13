import { SELECT_COMPONENT, HIGHLIGHT_COMPONENT, UNHIGHLIGHT_COMPONENT } from '../actions';

const selection = (state = {}, action) => {
    switch (action.type) {
        case SELECT_COMPONENT:
        {
            const { selectedComponent, ...newState } = state;

            return (selectedComponent === action.payload.componentPath && action.payload.toggle ) 
                ? newState
                : {
                    ...state,
                        selectedComponent: action.payload.componentPath
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

        case UNHIGHLIGHT_COMPONENT:
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