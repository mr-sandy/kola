var $ = require('jquery');
var template = require('app/templates/TextEditorTemplate.hbs');

module.exports = {
    propertyType: 'text',

    render: function(el, value) {
        $(el).html(template(value));

        var span = $(el).find('span');
        span.click(function () { alert('clicked!'); });
    }
}