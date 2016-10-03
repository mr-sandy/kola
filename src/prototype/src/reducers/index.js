import { combineReducers } from 'redux';
import components from './components';
import template from './template';
import selection from './selection';

export default combineReducers({ components, template, selection });

const sampleState = {
    components: [
        { name: 'Component 1' },
        { name: 'Component 2' },
        { name: 'Component 3' },
        { name: 'Component 4' }
    ],
    template: {
        fetching: false,
        template: {},
        templatePath: ''
    },
    selection: {
        selectedComponent: {},
        selectedProperty: {}
    }
};

// For property editing, need to know if the value edit mode
const refactoredState = {
    components: [],
    template: {
        fetching: false,
        template: {},
        templatePath: ''
    },
    selection: {
        selectedComponent: {},
        selectedProperty: {}
    }
};