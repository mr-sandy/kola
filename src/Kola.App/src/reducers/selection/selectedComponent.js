import { SELECT_COMPONENT } from '../../actions';

const selectedComponent = (state = '', action) => {
    switch (action.type) {
        case SELECT_COMPONENT:
        {
            return (state === action.payload.componentPath && action.payload.toggle ) 
                ? ''
                : action.payload.componentPath;
        }

        default:
            return state;
    }
}

export default selectedComponent;