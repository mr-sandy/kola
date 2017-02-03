import { combineReducers } from 'redux';
import components from './components';
import template from './template';
import selection from './selection';

const rootReducer = combineReducers({
    components,
    template,
    selection
});

export default rootReducer;