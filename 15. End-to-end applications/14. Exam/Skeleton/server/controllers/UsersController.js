'use strict';

var encryption = require('../utilities/encryption'),
    users = require('../data/users'),
    events = require('../data/events'),
    uploading = require('../utilities/uploading');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegister: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    postRegister: function (req, res, next) {
        req.pipe(req.busboy);

        var newUserData = {};

        req.busboy.on('file', function (fieldname, file, filename) {
            if (filename === '') {
                newUserData[fieldname] = 'default-avatar.jpg';
                file.resume();
            }
            else {
                var fileEnding = filename.substring(filename.lastIndexOf('.'), filename.length);
                filename = newUserData.username + fileEnding;

                newUserData[fieldname] = filename;
                uploading.saveFile(file, '/', filename);
            }
        });

        req.busboy.on('field', function (fieldname, val) {
            if (val !== '') {
                newUserData[fieldname] = val;
            }
        });

        req.busboy.on('finish', function () {


            if (newUserData.password !== newUserData.confirmPassword) {
                req.session.error = 'Passwords do not match!';
                res.redirect('/register');
            }
            else if (newUserData.password.length < 6 || newUserData.password.length > 20) {
                req.session.error = 'Passwords must be between 6 and 20 characters!';
                res.redirect('/register');
            }
            else if (newUserData.password.indexOf('.') >= 0 ||
                newUserData.password.indexOf('_') >= 0 ||
                newUserData.password.indexOf(' ') >= 0
                ) {
                req.session.error = 'Password cant contain the symbols "_" (underscore), " " (space) and "." (dot)!';
                res.redirect('/register');
                //todo: only alphabetic and numbers
            }
            else {
                newUserData.salt = encryption.generateSalt();
                newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

                //points
                newUserData.eventPoints = {
                    venue: 0,
                    organization: 0
                };

                users.create(newUserData, function (err, user) {
                    if (err) {
                        req.session.error = 'Failed to register, please try again! ' + err.toString();
                        res.redirect('/register');
                    }
                    else {
                        req.logIn(user, function (err) {
                            if (err) {
                                req.session.error = 'Failed to login, please try again!';
                                res.redirect('/login');
                            }
                            else {
                                res.redirect('/');
                            }
                        });
                    }
                });
            }
        });
    },
    getLogin: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function (req, res, next) {

        var createdByMeFilter = {
            page: 1,
            creator: req.user._id
        };

        var joinedFilter = {
            page: 1,
            joinedBy: req.user._id
        };

        var pastFilter = {
            page: 1,
            creator: req.user._id,
            isPast: true
        };


        events.getQuery(createdByMeFilter, function (err, createdByMeEvents) {
            if (err) {
                req.session.error = 'Cant load created by me events, please check you connection';
                res.redirect('/');
            }
            else {
                events.getQuery(joinedFilter, function (err, joinedEvents) {
                    if (err) {
                        req.session.error = 'Cant load joinde events, please check you connection';
                        res.redirect('/');
                    }
                    else {
                        events.getQuery(pastFilter, function (err, pastEvents) {
                            if (err) {
                                req.session.error = 'Cant load joined events, please check you connection';
                                res.redirect('/');
                            }
                            else {
                                res.render(CONTROLLER_NAME + '/profile', { user: req.user, createdByMeEvents: createdByMeEvents,
                                    joinedEvents: joinedEvents, pastEvents: pastEvents });
                            }
                        });
                    }
                });
            }
        });
    },
    postProfile: function (req, res, next) {
            var user = req.user;

            req.pipe(req.busboy);

            var updatedUserData = {};

            req.busboy.on('file', function (fieldname, file, filename) {
                if (filename === '') {
                    if (!user.profilePicture) {
                        updatedUserData[fieldname] = 'default-avatar.jpg';
                    }
                    file.resume();
                }
                else {
                    var fileEnding = filename.substring(filename.lastIndexOf('.'), filename.length);
                    filename = user.username + fileEnding;

                    updatedUserData[fieldname] = filename;
                    uploading.saveFile(file, '/', filename);
                }
            });

            req.busboy.on('field', function (fieldname, val) {
                if (val !== '') {
                    updatedUserData[fieldname] = val;
                }
            });

            req.busboy.on('finish', function () {
                users.update(user._id, updatedUserData, function (err, resp) {
                    if (err) {
                        req.session.error = 'Failed to update profile, please try again! ' + err.toString();
                        res.redirect('/profile');
                    }
                    else {
                        res.redirect('/profile');
                    }
                });
            });

        }
    };