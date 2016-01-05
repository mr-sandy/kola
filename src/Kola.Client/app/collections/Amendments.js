var $ = require('jquery');
var Backbone = require('backbone');
var Amendment = require('app/models/Amendment');
var UndoResponse = require('app/models/UndoResponse');

module.exports = Backbone.Collection.extend({

    parse: function (response, options) {

        if (options.url) {
            this.url = options.url;
        }

        return response;
    },

    addComponent: function (componentType, targetPath) {
        this._saveAmendment({ componentType: componentType, targetPath: targetPath }, 'addComponent');
    },

    moveComponent: function (sourcePath, targetPath) {
        this._saveAmendment({ sourcePath: sourcePath, targetPath: targetPath }, 'moveComponent');
    },

    removeComponent: function (componentPath) {
        this._saveAmendment({ componentPath: componentPath }, 'removeComponent');
    },

    duplicateComponent: function (componentPath) {
        this._saveAmendment({ componentPath: componentPath }, 'duplicateComponent');
    },

    //setProperty: function (event) {
    //    this._saveAmendment({ componentPath: event.componentPath, propertyName: event.propertyName, value: event.value }, 'setProperty');
    //},

    resetProperty: function (componentPath, propertyName) {
        this._saveAmendment({ componentPath: componentPath, propertyName: propertyName }, 'resetProperty');
    },

    setPropertyFixed: function (componentPath, propertyName, value) {
        this._saveAmendment({ componentPath: componentPath, propertyName: propertyName, value: value }, 'setPropertyFixed');
    },

    setPropertyInherited: function (componentPath, propertyName, key) {
        this._saveAmendment({ componentPath: componentPath, propertyName: propertyName, key: key }, 'setPropertyInherited');
    },

    setComment: function (componentPath, comment) {
        this._saveAmendment({ componentPath: componentPath, comment: comment }, 'setComment');
    },

    _saveAmendment: function (attributes, type) {
        var amendment = new Amendment(attributes);
        this.add(amendment);
        amendment.save(null, { url: this.url + '&amendmentType=' + type });
    },

    applyAmendments: function () {
        var self = this;
        $.ajax({ type: 'PUT', url: this.url }).then(function () { self.fetch({ reset: true }); });
    },

    undoAmendment: function () {
        var self = this;
        $.ajax({ type: 'DELETE', url: this.url }).then(function (resp) {
            self.fetch({ reset: true });
            self.trigger('undo', new UndoResponse(resp, { parse: true }));
        });
    }
});
