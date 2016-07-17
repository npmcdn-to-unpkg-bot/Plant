/// <binding AfterBuild='ng2' Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    concat = require('gulp-concat'),
    sourcemaps = require('gulp-sourcemaps'),
    ts = require('gulp-typescript');

var webroot = "./wwwroot/";

var paths = {
    js: webroot + "js/**/*.js",
    minJs: webroot + "js/**/*.min.js",
    css: webroot + "css/**/*.css",
    minCss: webroot + "css/**/*.min.css",
    concatJsDest: webroot + "js/site.min.js",
    concatCssDest: webroot + "css/site.min.css"
};

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);


gulp.task("ng2", function() {
    gulp.src([
        "node_modules/angular2/bundles/*.*",
        "node_modules/systemjs/dist/*.*",
        "node_modules/es6-shim/*.*"
    ])
    .pipe(gulp.dest("wwwroot/lib/ng2"));
});

gulp.task("rxjs", function () {
    gulp.src([
        "node_modules/rxjs/*.*"
    ])
    .pipe(gulp.dest("wwwroot/lib/rxjs"));
});

gulp.task("requirejs", function () {
    gulp.src([
        "node_modules/requirejs/*.*"
    ])
    .pipe(gulp.dest("wwwroot/lib/requirejs"));
});

gulp.task('scripts', function () {
    var tsResult = gulp.src('wwwroot/app/*.ts')
        .pipe(sourcemaps.init()) // This means sourcemaps will be generated
        .pipe(ts({
            sortOutput: true,
        }));

    return tsResult.js
        .pipe(sourcemaps.write()) // Generate .js.map file for .ts
        .pipe(sourcemaps.write('/', {   // Generate .js.map file
            mapFile: function (mapFilePath) {
                return mapFile;
            }
        }))
        .pipe(gulp.dest('wwwroot/app/'));
});

gulp.task("subject", function () {
    gulp.src([
        "node_modules/subject/**/*.*"
    ])
    .pipe(gulp.dest("wwwroot/lib/subject"));
});