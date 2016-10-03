import { combineReducers } from 'redux';
import { SELECT_COMPONENT, SELECT_PROPERTY } from '../actions';

function selectedComponent (state = {}, action) {
    switch (action.type) {
        case SELECT_COMPONENT:
            return state === action.payload.component ? {} : action.payload.component; 

        default:
            return state;
    }
}

function selectedProperty (state = {}, action) {
    switch (action.type) {
        case SELECT_PROPERTY:
            return action.payload.property; 

        default:
            return state;
    }
}

export default combineReducers({ selectedComponent, selectedProperty });