'use strict';

var watchify = require('watchify');
var browserify = require('browserify');
var reactify = require('reactify');
var gulp = require('gulp');
var source = require('vinyl-source-stream');
var gutil = require('gulp-util');
var assign = require('object-assign');
var browserSync = require('browser-sync').create();
var sass = require('gulp-sass');

// add custom browserify options here
var customOpts = {
    entries: ['./js/app.js'],
    debug: true
};
var opts = assign({}, watchify.args, customOpts);
var b = watchify(browserify(opts));
var reload = browserSync.reload;

b.transform(reactify);

b.on('update', bundle); // on any dep update, runs the bundler
b.on('log', gutil.log); // output build logs to terminal

function bundle() {
    return b.bundle()
        // log errors if they happen
        .on('error', gutil.log.bind(gutil, 'Browserify Error'))
        .pipe(source('bundle.js'))
        .pipe(gulp.dest('./js'))
        .pipe(reload({
            stream: true,
            once: true
        }));
}

gulp.task('bundle', bundle);

gulp.task('sass', function() {
    return gulp.src("./scss/*.scss")
        .pipe(sass())
        .pipe(gulp.dest("./css"))
        .pipe(browserSync.stream());
});

gulp.task('fontawesome', ['fontawesome-fonts', 'fontawesome-css']);

gulp.task('fontawesome-fonts', function() {
    return gulp.src('./node_modules/font-awesome/fonts/**.*')
        .pipe(gulp.dest('./fonts'));
});

gulp.task('fontawesome-css', function() {
    return gulp.src('./node_modules/font-awesome/css/**.min.*')
        .pipe(gulp.dest('./css'));
});

gulp.task('serve', ['sass', 'bundle', 'fontawesome'], function() {

    browserSync.init({
        server: {
            baseDir: "./"
        }
    });

    gulp.watch("./scss/*.scss", ['sass']);
    gulp.watch("./*.html").on('change', browserSync.reload);
});

