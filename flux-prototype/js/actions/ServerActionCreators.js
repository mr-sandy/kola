var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/AppConstants').ActionTypes;

module.exports = {

    receiveTemplate: function(rawTemplate) {
        AppDispatcher.dispatch({
            type: ActionTypes.RECEIVE_RAW_TEMPLATE,
            rawTemplate: rawTemplate
        });
    }
};
