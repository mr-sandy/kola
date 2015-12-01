var $ = require('jquery');
var template = require('app/templates/MarkdownEditorTemplate.hbs');

module.exports = {
    propertyType: 'markdown',

    render: function(el, value) {
        $(el).html(template(value));
    }
}