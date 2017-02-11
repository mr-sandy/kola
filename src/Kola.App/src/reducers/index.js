import { combineReducers } from 'redux';
import componentTypes from './componentTypes';
import template from './template';
import selection from './selection';
import application from './application';

const rootReducer = combineReducers({
    componentTypes,
    template,
    selection,
    application
});

export default rootReducer;