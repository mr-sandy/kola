var ServerActionCreators = require('../actions/ServerActionCreators');

function jsonp(url, callback) {
    var callbackName = 'jsonp_callback_' + Math.round(100000 * Math.random());
    window[callbackName] = function (data) {
        delete window[callbackName];
        document.body.removeChild(script);
        callback(data);
    };

    var script = document.createElement('script');
    script.src = url + (url.indexOf('?') >= 0 ? '&' : '?') + 'callback=' + callbackName;
    document.body.appendChild(script);
}

module.exports = {

    getTemplate: function () {
        setTimeout(function () {
                var rawTemplate = {
                    components: [
                        {
                            type: 'atom',
                            name: 'markdown',
                            path: '0'
                        },
                        {
                            type: 'atom',
                            name: 'markdown',
                            path: '1'
                        },
                        {
                            type: 'container',
                            name: 'division',
                            path: '2',
                            components: [
                                {
                                    type: 'atom',
                                    name: 'markdown',
                                    path: '2/0'
                                },
                                {
                                    type: 'atom',
                                    name: 'markdown',
                                    path: '2/1'
                                },
                                {
                                    type: 'container',
                                    name: 'division',
                                    path: '2/2',
                                    components: [
                                        {
                                            type: 'atom',
                                            name: 'markdown',
                                            path: '2/2/0'
                                        },
                                        {
                                            type: 'atom',
                                            name: 'markdown',
                                            path: '2/2/1'
                                        }
                                    ]
                                }
                            ]
                        }
                    ],
                };
                ServerActionCreators.receiveTemplate(rawTemplate);
            }, 100
        )
        ;
    },

    getTemplate3: function () {
        jsonp('http://localhost:51969/_kola/templates/jam', function (data) {
            var rawTemplate = data; //JSON.parse(data);
            ServerActionCreators.receiveTemplate(rawTemplate);
        });
    }
    ,

    getTemplate2: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('GET', encodeURI('http://localhost:51969/_kola/templates/jam'));
        xhr.onload = function () {
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
}
;
