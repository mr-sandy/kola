var React = require('react');
var TemplateWebApiUtils = require('./utils/TemplateWebApiUtils.js');

var MyApp = require('./components/MyApp.js');

TemplateWebApiUtils.getTemplate();

React.render(
    <MyApp />,
    document.getElementById('app')
);
