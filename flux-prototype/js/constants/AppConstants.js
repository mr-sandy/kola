var keyMirror = require('react/lib/keyMirror');

module.exports = {
    ActionTypes: keyMirror({
        SELECT_COMPONENT: null,
        DESELECT_COMPONENT: null,
        EXPAND_COMPONENT: null,
        COLLAPSE_COMPONENT: null,
        RECEIVE_RAW_TEMPLATE: null
    })
};
