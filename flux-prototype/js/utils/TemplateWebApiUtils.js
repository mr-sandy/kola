var ServerActionCreators = require('../actions/ServerActionCreators');

function jsonp(url, callback) {
    var callbackName = 'jsonp_callback_' + Math.round(100000 * Math.random());
    window[callbackName] = function(data) {
        delete window[callbackName];
        document.body.removeChild(script);
        callback(data);
    };

    var script = document.createElement('script');
    script.src = url + (url.indexOf('?') >= 0 ? '&' : '?') + 'callback=' + callbackName;
    document.body.appendChild(script);
}

module.exports = {

    getTemplate: function() {
        jsonp('http://localhost:51969/_kola/templates/jam', function(data) {
            var rawTemplate = data; //JSON.parse(data);
            ServerActionCreators.receiveTemplate(rawTemplate);
        });
    },

    getTemplate2: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', encodeURI('http://localhost:51969/_kola/templates/jam'));
        xhr.onload = function() {
            if (xhr.status === 200) {
                var rawTemplate = JSON.parse(xhr.responseText);
                ServerActionCreators.receiveTemplate(rawTemplate);
            }
            else {
                alert('Request failed.  Returned status of ' + xhr.status);
            }
        };
        xhr.send();
    }
};
