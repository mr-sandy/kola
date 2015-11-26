var template = require('app/templates/TextEditorTemplate.hbs');

module.exports = {
    propertyType: 'text',

    render: function($el, value) {
        $el.html(template(value));
    }
}