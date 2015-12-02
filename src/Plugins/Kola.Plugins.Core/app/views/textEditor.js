var $ = require('jquery');
var template = require('app/templates/TextEditorTemplate.hbs');


module.exports = {
    propertyType: 'text',

    render: function (el, value, editMode) {

        this.$el = $(el);

        var context = {
            value: value,
            editMode: editMode
        };

        this.$el.html(template(context));
    },

    value: function() {
        return this.$el.find('input').val();
    }
}