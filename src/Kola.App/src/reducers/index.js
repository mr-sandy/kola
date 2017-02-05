import { combineReducers } from 'redux';
import components from './components';
import template from './template';
import selection from './selection';
import application from './application';

const rootReducer = combineReducers({
    components,
    template,
    selection,
    application
});

export default rootReducer;