var gulp = require('gulp');
var plumber = require('gulp-plumber');
var watch = require('gulp-watch');
var sourcemaps = require('gulp-sourcemaps');
var sass = require('gulp-sass');
var rename = require('gulp-rename');

gulp.task('sass', function () {
    gulp.src('./sass/**/*.scss')
        .pipe(plumber())
        .pipe(sourcemaps.init())
        .pipe(sass({ outputStyle: 'compressed' }))
        .pipe(sourcemaps.write())
        .pipe(rename('kola.min.css'))
        .pipe(gulp.dest('./content'));
});

gulp.task('watch', function () {
    gulp.watch('./sass/**/*.scss', ['sass']);

});

gulp.task('default', ['watch']);