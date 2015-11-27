var path = require('path');

module.exports = {
    entry: './app/app.js',

    output: {
        path: './scripts',
        filename: 'kola.js'
    },

    resolve: {
        root: path.resolve('./'),
        extensions: ['', '.js']
    },

    devtool: 'inline-source-map',

    module: {
        loaders: [
            {
                test: /\.js/,
                exclude: /node_modules/,
                loader: 'babel-loader'
            },
            {
                test: /\.hbs/,
                loader: 'handlebars-loader'
            }
        ]
    }
}
