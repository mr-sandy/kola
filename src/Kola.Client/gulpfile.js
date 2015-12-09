/// <binding ProjectOpened='default' />
var gulp = require('gulp');
var plumber = require('gulp-plumber');
var watch = require('gulp-watch');
var sourcemaps = require('gulp-sourcemaps');
var sass = require('gulp-sass');
var rename = require('gulp-rename');
var webpack = require('webpack');
var gutil = require('gulp-util');
var webpackConfig = require('./webpack.config.js');

var devCompiler = webpack(webpackConfig);

gulp.task('sass', function () {
    gulp.src('./sass/**/*.scss')
        .pipe(plumber())
        .pipe(sourcemaps.init())
        .pipe(sass({ outputStyle: 'compressed' }))
        .pipe(sourcemaps.write())
        .pipe(rename('kola.min.css'))
        .pipe(gulp.dest('./content'));
});

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

gulp.task('watch-sass', ['sass'], function () {
    gulp.watch('./sass/**/*.scss', ['sass']);
});

gulp.task('default', ['watch-sass', 'watch-js']);