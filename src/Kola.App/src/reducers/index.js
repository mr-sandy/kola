import { combineReducers } from 'redux';
import componentTypes from './componentTypes';
import template from './template';
import amendments from './amendments';
import selection from './selection';
import application from './application';

const rootReducer = combineReducers({
    componentTypes,
    template,
    amendments,
    selection,
    application
});

export default rootReducer;