'use strict';

var encryption = require('../utilities/encryption');
var users = require('../data/users');
var User = require('mongoose').model('User');


module.exports = {
    me: function (req, res, next) {

    },
    update: function (req, res, next) {
        if (req.user._id ==  req.body._id) {
            var updatedUserData = {
                firstName: req.body.firstName,
                lastName: req.body.lastName,
                username: req.body.username,
                password: req.body.password,
                confirmPassword: req.body.confirmPassword
            };

            if (updatedUserData.password && updatedUserData.password.length > 0) {

                if (updatedUserData.password !== updatedUserData.confirmPassword) {
                    req.session.errorMessage = 'Passwords do not match!';
                    res.status(400).send({reason: 'Passwords do not match!'});
                    return;
                }
                updatedUserData.salt = encryption.generateSalt();
                updatedUserData.hashPass = encryption.generateHashedPassword(updatedUserData.salt, updatedUserData.password);
            }

            User.update({ _id: req.body._id }, updatedUserData, function (err, numberAffectedRows) {
                if (err) {
                    res.status(400);
                    res.send({message: 'User cannot be found!'});
                    return;
                }
                res.send();
            });
        }
        else {
            res.send({reason: 'You do not have permissions!'});
        }
    },
    deleteUser: function (req, res, next) {
        User
            .findOne({ _id: req.user.id })
            .remove()
            .exec(function (err, count) {
                if (err) {
                    res.status(400);
                    res.send({message: 'Username cannot be found!'});
                    console.log('User could not be found: ' + err);
                    return;
                }

                res.status(200).send();
            });
    },
    register: function (req, res, next) {

        var newUserData = {
            firstName: req.body.firstName,
            lastName: req.body.lastName,
            username: req.body.username,
            password: req.body.password,
            confirmPassword: req.body.confirmPassword
        };

        if (newUserData.password !== newUserData.confirmPassword) {
            res.status(400);

            return res.send({reason: 'Passwords do not match!'});
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, req.body.password);
            newUserData.roles = ['user'];
            users.create(newUserData, function (err, user) {
                if (err) {
                    res.status(400);
                    res.send({message: 'Username already exists!'});
                    return;
                }

                req.logIn(user, function (err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()});
                    }
                    res.send(user);
                });
            });
        }
    }
};