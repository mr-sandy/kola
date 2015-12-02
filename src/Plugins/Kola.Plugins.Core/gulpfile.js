/// <binding ProjectOpened='default' />
var gulp = require('gulp');
var webpack = require('webpack');
var gutil = require('gulp-util');
var webpackConfig = require('./webpack.config.js');

var devCompiler = webpack(webpackConfig);

gulp.task('webpack', function (callback) {
    devCompiler.run(function (err, stats) {
        if (err) throw new gutil.PluginError('webpack', err);
        gutil.log('[webpack]', stats.toString({ colors: true }));
        callback();
    });
});

gulp.task('watch-js', ['webpack'], function () {
    gulp.watch(['app/**/*'], ['webpack']);
});

gulp.task('default', ['watch-js']);