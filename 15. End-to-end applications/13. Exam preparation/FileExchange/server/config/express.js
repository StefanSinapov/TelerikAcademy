'use strict';

var express = require('express'),
    path = require('path'),
    stylus = require('stylus'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport'),
    busboy = require('connect-busboy');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', path.join(config.rootPath, '/server/views'));

    app.use(busboy({ immediate: false }));
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true}));
    app.use(cookieParser());
    app.use(session({
        secret: 'cookie_secret',
        name: 'cookie_name',
        proxy: true,
        resave: true,
        saveUninitialized: true
    }));

    app.use(stylus.middleware(
        {
            src: path.join(config.rootPath, '/public'),
            compile: function (str, path) {
                return stylus(str).set('filename', path);
            }
        }
    ));

    app.use(passport.initialize());
    app.use(passport.session());
    app.use(express.static(path.join(config.rootPath, '/public')));

    app.use(function(req, res, next) {
        if (req.session.errorMessage) {
            app.locals.errorMessage = req.session.errorMessage;
        }
        next();
    });

    // This may cause problems
    app.use(function(req, res, next) {
        app.locals.currentUser = req.user;
        next();
    });


    // error handlers

    // development error handler
    // will print stacktrace
    if (app.get('env') === 'development') {
        app.use(function(err, req, res, next) {
            res.status(err.status || 500);
            res.render('error', {
                message: err.message,
                error: err
            });
        });
    }

    // production error handler
    // no stacktraces leaked to user
    app.use(function(err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: {}
        });
    });
};