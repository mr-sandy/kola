var Backbone = require('backbone');
var _ = require('underscore');
var template = require('app/templates/PropertyTemplate.hbs');

module.exports = Backbone.View.extend({

    template: template,

    tagName: 'div',

    className: 'property',

    initialize: function (options) {
        this.editMode = false;
        this.amendments = options.amendments;
        this.componentPath = options.componentPath;
    },

    render: function () {

        this.$el.html(this.template(this.model));

        if (this.model.value) {
            switch (this.model.value.type) {
                case 'fixed':
                    this.renderFixed();
                    break;
                case 'inherited':
                    this.renderInherited();
                    break;
                default:
            }
        }
        //var propertyType = this.model.type;
        //var plugin = _.find(kola.propertyEditors, function (ed) {
        //    return ed.propertyType === propertyType;
        //});

        //if (plugin) {
        //    this.$el.html(this.template(this.model));
        //    var $editorElement = this.$el.find('.value').last();

        //    plugin.render($editorElement, this.model.value.value);
        //}

        return this;
    },

    renderFixed: function () { },

    renderInherited: function () { }

});