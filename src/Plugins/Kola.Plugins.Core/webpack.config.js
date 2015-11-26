var path = require('path');

module.exports = {
    entry: './app/App.js',

    output: {
        path: './editors/scripts',
        filename: 'editor.js'
    },

    resolve: {
        root: path.resolve('./'),
        extensions: ['', '.js']
    },

    devtool: 'inline-source-map',

    module: {
        loaders: [{ test: /\.hbs/, loader: 'handlebars-loader' }]
    }
}
