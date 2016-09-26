import { REQUEST_TEMPLATE, RECEIVE_TEMPLATE } from '../actions';

const initialState = {
    fetching: false,
    template: {},
    templatePath: ''
};

export default function template(state = initialState, action) {
    switch (action.type) {
        case REQUEST_TEMPLATE:
            return {
                fetching: true,
                template: {},
                templatePath: action.payload.templatePath
            }

        case RECEIVE_TEMPLATE:
            return {
                fetching: false,
                template: action.payload.template,
                templatePath: action.payload.templatePath
            }

        default:
            return state;
    }
}