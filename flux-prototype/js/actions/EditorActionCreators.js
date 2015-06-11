var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/AppConstants').ActionTypes;

module.exports = {

    selectComponent: function(component) {
        AppDispatcher.dispatch({
            type: ActionTypes.SELECT_COMPONENT,
            component: component
        });
    },

    deselectComponent: function(component) {
        AppDispatcher.dispatch({
            type: ActionTypes.DESELECT_COMPONENT,
            component: component
        });
    },

    expandComponent: function(component) {
        AppDispatcher.dispatch({
            type: ActionTypes.EXPAND_COMPONENT,
            component: component
        });
    },

    collapseComponent: function(component) {
        AppDispatcher.dispatch({
            type: ActionTypes.COLLAPSE_COMPONENT,
            component: component
        });
    }
};
