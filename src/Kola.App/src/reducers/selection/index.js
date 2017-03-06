import { combineReducers } from 'redux';
import selectedComponent from './selectedComponent';
import highlightedComponent from './highlightedComponent';
import placeholderPath from './placeholderPath';
import hiddenComponent from './hiddenComponent';
import selectedProperty from './selectedProperty';

const selection = combineReducers({
    selectedComponent,
    highlightedComponent,
    placeholderPath,
    hiddenComponent,
    selectedProperty
});

export default selection;