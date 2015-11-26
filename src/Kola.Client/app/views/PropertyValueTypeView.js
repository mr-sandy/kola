var Backbone = require('backbone');
var $ = require('jquery');
var _ = require('underscore');
var template = require('app/templates/PropertyValueTypeTemplate.hbs');

module.exports = Backbone.View.extend({

    valueTypes: [ 'fixed', 'inherited'],

    template: template,

    initialize: function() {
        this.expanded = false;
    },

    events: {
        'click button': 'toggleDropdown',
        'click .valueTypeOption': 'selectValueType'
},

    render: function () {
        var selectedValueType = this.model;

        var valueTypes = _.map(this.valueTypes, function(v) {
            return {
                name: v,
                selected: v === selectedValueType
            }
        });

        var context = {
            valueType: selectedValueType,
            valueTypes: valueTypes,
            expanded: this.expanded
        };

        this.$el.html(this.template(context));

        return this;
    },

    toggleDropdown: function(e) {
        this.expanded = !this.expanded;
        this.render();
    },

    selectValueType: function (e) {
        var selectedType = e.target.textContent;
        this.model = selectedType;

        this.expanded = false;
        this.render();

        //var self = this;
        //setTimeout(function () {
        //    self.expanded = false;
        //    self.render();
        //}, 250);
    }
});