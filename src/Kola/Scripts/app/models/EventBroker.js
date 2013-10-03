define([
        'backbone'
], function (Backbone) {
    'use strict';

    return Backbone.Model.extend(
    {
        handleAddComponent: function (componentType, componentPath, index) {
            alert('added new component of type ' + componentType + ' to parent ' + componentPath + ' at index ' + index);
        },

        handleMoveComponent: function (componentPath, parentComponentPath, index) {
            alert('moved ' + componentPath + ' to new parent ' + parentComponentPath + ' at index ' + index);
        }
    });
});