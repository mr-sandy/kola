import { combineReducers } from 'redux';
import components from './components';
import template from './template';
import selection from './selection';

export default combineReducers({ components, template, selection });