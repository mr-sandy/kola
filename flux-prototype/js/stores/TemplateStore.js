var AppDispatcher = require('../dispatcher/AppDispatcher');
var ActionTypes = require('../constants/AppConstants').ActionTypes;
var EventEmitter = require('events').EventEmitter;
var Immutable = require('immutable');
var _ = require('lodash');
var assign = require('object-assign');

var CHANGE_EVENT = 'change';

var _template = {};
var _selectedComponent = null;

function init(rawTemplate) {
    _template = Immutable.fromJS(rawTemplate);
}

function selectComponent(component) {

    if (_selectedComponent)
    {
        deselectComponent(_selectedComponent);
    }

    var componentPath = getComponentPath(component);
    var keyPath = buildKeyPath(componentPath);

    keyPath.push('selected');

    _template = _template.setIn(keyPath, true);
    _selectedComponent = component;
}

function deselectComponent(component) {
    var componentPath = getComponentPath(component);
    var keyPath = buildKeyPath(componentPath);

    keyPath.push('selected');

    _template = _template.deleteIn(keyPath);
    _selectedComponent = null;
}

function expandComponent(component) {
    var componentPath = getComponentPath(component);
    var keyPath = buildKeyPath(componentPath);

    keyPath.push('collapsed');

    _template = _template.deleteIn(keyPath);
}

function collapseComponent(component) {
    var componentPath = getComponentPath(component);
    var keyPath = buildKeyPath(componentPath);

    keyPath.push('collapsed');

    _template = _template.setIn(keyPath, true);
}

function getComponentPath(component) {
    return _.chain(component.get('path').split('/'))
        .without('')
        .map(_.parseInt)
        .value();
}

function buildKeyPath(path) {

    var keyPath = [];

    if (path.length !== 0) {

        keyPath.push('components');

        for (var i = 0; i < path.length; i++) {
            var index = path[i];
            keyPath.push(index);

            if (i !== path.length - 1)
            {
                var componentType = _template.getIn(keyPath).get('type');
                switch (componentType){
                    case 'widget':
                        keyPath.push('areas');
                        break;
                    default:
                        keyPath.push('components');
                        break;
                }
            }
        }
    }

    return keyPath;
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
