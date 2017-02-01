import { combineReducers } from 'redux';
import components from './components';
import template from './template';

const rootReducer = combineReducers({
    components,
    template
});

export default rootReducer;