import { SELECT_COMPONENT, HIGHLIGHT_COMPONENT, UNHIGHLIGHT_COMPONENT, SHOW_PLACEHOLDER, HIDE_PLACEHOLDER } from '../actions';

const selection = (state = { }, action) => {
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

        case SHOW_PLACEHOLDER:
        {
            const { placeholderPath, ...newState } = state;

            return (placeholderPath === action.payload) 
                ? state
                : {
                    ...newState,
                    placeholderPath: action.payload
                };
        }

        case HIDE_PLACEHOLDER:
        {
            const { placeholderPath, ...newState } = state;

            return newState;
        }

        default:
            return state;
    }
}

export default selection;