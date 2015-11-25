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

    setProperty: function (event) {
        this._saveAmendment({ componentPath: event.componentPath, propertyName: event.propertyName, value: event.value }, 'setProperty');
    },

    setComment: function (componentPath, comment) {
        this._saveAmendment({ componentPath: componentPath, comment: comment }, 'setComment');
    },

    _saveAmendment: function (attributes, type) {
        var amendment = new Amendment(attributes);
        this.add(amendment);
        amendment.save(null, { url: this.combineUrls(this.url, type) });
    },

    applyAmendments: function () {
        var self = this;
        $.post(this.combineUrls(this.url, 'apply')).then(function () { self.fetch({ reset: true }); });
    },

    undoAmendment: function () {
        var self = this;
        $.post(this.combineUrls(this.url, 'undo')).then(function (resp) {
            self.fetch({ reset: true });
            self.trigger('undo', new UndoResponse(resp, { parse: true }));
        });
    }
});
