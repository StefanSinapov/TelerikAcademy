var encryption = require('../utilities/encryption');
var User = require('mongoose').model('User');

var controllerName = 'users';

module.exports = {
    getRegister: function(req, res, next) {
        res.render(controllerName + '/register');
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;
        if (newUserData.password != newUserData.confirmPassword) {
            req.session.errorMessage = 'Passwords do not match!';
            res.redirect('/register');
        }
        else {
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            User.create(newUserData, function(err, user) {
                if (err) {
                    req.session.errorMessage = err;
                    res.redirect('/register');
                    return;
                }

                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()}); // create error page
                    };

                    res.redirect('/');
                });
            });
        }
    },
    getLogin: function(req, res, next) {
        res.render(controllerName + '/login-user');
    },
    postLogin: function(req, res, next) {
        if (req.user) {
            res.redirect('/');
        }
        else {
            res.redirect('/login');
        }
    },
    logout: function(req, res, next) {
        res.redirect('/');
    }
};