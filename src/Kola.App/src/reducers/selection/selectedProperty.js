import * as actions from '../../actions';

const selectedProperty = (state = null, action) => {
    switch (action.type) {
        case actions.SELECT_PROPERTY:
            {
                if (!action.payload) {
                    return null;

                } else if (!state) {
                    return action.payload || null;

                } else if (state.name !== action.payload.name) {
                    return action.payload

                } else {
                    return state;
                }
            }

        case actions.SET_PROPERTY_VALUE_TYPE:
            return {
                ...state,
                value: {
                    ...state.value,
                    type: action.payload
                }
            }

        case actions.SET_PROPERTY_VALUE:
            return {
                ...state,
                value: action.payload
            }

        case actions.SELECT_COMPONENT:
            return null;

        default:
            return state;
    }
}

export default selectedProperty;