var AppView = require('app/views/AppView');
var Router = require('app/Router');
require('app/Extensions');


var appView = new AppView({
    router: new Router()
});

appView.render();

Backbone.history.start({ pushState: true });
