var React = require('react');
var BlockEditor = require('./BlockEditor.js');


var MyApp = React.createClass({

    render: function () {
        return (
            <div className="myApp">
                <BlockEditor />
            </div>
        );
    }
});

module.exports = MyApp;