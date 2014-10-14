'use strict';

var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {

    // User
    app.route('/api/users')
        .get(auth.isAuthenticated, controllers.users.me) //or users.all
        .put(auth.isAuthenticated, controllers.users.update)
        .delete(auth.isAuthenticated, controllers.users.deleteUser);

    app.post('/auth/login', auth.login);
    app.get('/auth/logout', auth.logout);
    app.post('/auth/register', controllers.users.register);

    //Views /partials/user/register => /public/js/user/partials/register.jade
    app.get('/partials/:partialArea/:partialName', function (req, res) {
        res.render('../../public/js/' + req.params.partialArea + '/partials/' + req.params.partialName);
    });

    app.get('/api/*', function (req, res) {
        res.render('index');
        res.status(404);
        res.end();
    });

    app.get('*', function (req, res) {
        res.render('index');
    });
};
