var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/AppConstants').ActionTypes;
var EventEmitter = require('events').EventEmitter;
var Immutable = require('immutable');
var _ = require('lodash');
var assign = require('object-assign');

var CHANGE_EVENT = 'change';

var _template = {};
var _selectedComponent = null;

function makeComponentKey(index) {
    return ['components', index];
}

function buildKeyPath(componentPath, finalKey) {
    return _.chain(componentPath)
        .map(makeComponentKey)
        .flatten()
        .concat([finalKey])
        .value();
}

function annotatePaths(template, parentPath) {

    parentPath = parentPath || [];
    var componentsKeyPath = buildKeyPath(parentPath, 'components');

    if (template.hasIn(componentsKeyPath)) {
        for (var i = 0; i < template.getIn(componentsKeyPath).count(); i++) {
            var pathKeyPath = componentsKeyPath.concat([i, 'path']);
            if (template.hasIn(pathKeyPath)) {
                template = template.mergeIn(pathKeyPath, parentPath.concat([i]));
            }
            else {
                template = template.mergeIn(componentsKeyPath.concat([i]), {'path': parentPath.concat([i])});
            }
            template = annotatePaths(template, parentPath.concat([i]));
        }
    }
    return template;
}

function init(rawTemplate) {
    _template = annotatePaths(Immutable.fromJS(rawTemplate));
}

function selectComponent(component) {

    if (_selectedComponent) {
        deselectComponent(_selectedComponent);
    }

    var keyPath = buildKeyPath(component.get('path').toJS(), 'selected');

    _template = _template.setIn(keyPath, true);
    _selectedComponent = component;
}

function deselectComponent(component) {
    var keyPath = buildKeyPath(component.get('path').toJS(), 'selected');

    _template = _template.deleteIn(keyPath);
    _selectedComponent = null;
}

function expandComponent(component) {
    var keyPath = buildKeyPath(component.get('path').toJS(), 'collapsed');

    _template = _template.deleteIn(keyPath);
}

function collapseComponent(component) {
    var keyPath = buildKeyPath(component.get('path').toJS(), 'collapsed');

    _template = _template.setIn(keyPath, true);
}

var TemplateStore = assign({}, EventEmitter.prototype, {

    getTemplate: function () {
        return _template;
    },

    emitChange: function () {
        this.emit(CHANGE_EVENT);
    },

    addChangeListener: function (callback) {
        this.on(CHANGE_EVENT, callback);
    },

    removeChangeListener: function (callback) {
        this.removeListener(CHANGE_EVENT, callback);
    },

    dispatcherIndex: AppDispatcher.register(function (action) {

        switch (action.type) {
            case ActionTypes.RECEIVE_RAW_TEMPLATE:

                init(action.rawTemplate);
                TemplateStore.emitChange();
                break;

            case ActionTypes.SELECT_COMPONENT:

                selectComponent(action.component);
                TemplateStore.emitChange();
                break;

            case ActionTypes.DESELECT_COMPONENT:

                deselectComponent(action.component);
                TemplateStore.emitChange();
                break;

            case ActionTypes.EXPAND_COMPONENT:

                expandComponent(action.component);
                TemplateStore.emitChange();
                break;

            case ActionTypes.COLLAPSE_COMPONENT:

                collapseComponent(action.component);
                TemplateStore.emitChange();
                break;
        }

        return true; // No errors. Needed by promise in Dispatcher.
    })
});

module.exports = TemplateStore;
