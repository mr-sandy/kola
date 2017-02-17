import { combineReducers } from 'redux';
import selectedComponent from './selectedComponent';
import highlightedComponent from './highlightedComponent';
import placeholderPath from './placeholderPath';
import hiddenComponent from './hiddenComponent';

const selection = combineReducers({
    selectedComponent,
    highlightedComponent,
    placeholderPath,
    hiddenComponent
});

export default selection;