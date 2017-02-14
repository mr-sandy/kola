import { combineReducers } from 'redux';
import selectedComponent from './selectedComponent';
import highlightedComponent from './highlightedComponent';
import placeholderPath from './placeholderPath';

const selection = combineReducers({
    selectedComponent,
    highlightedComponent,
    placeholderPath
});

export default selection;