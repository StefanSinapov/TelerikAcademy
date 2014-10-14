'use strict';

var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {

    // User
    app.route('/api/users')
        .get(auth.isAuthenticated, controllers.users.me)
        .put(auth.isAuthenticated, controllers.users.update)
        .delete(auth.isAuthenticated, controllers.users.deleteUser);

    app.post('/auth/login', auth.login);
    app.get('/auth/logout', auth.logout);
    app.post('/auth/register', controllers.users.register);


    // Todos
    app.route('/api/todos')
        .get(auth.isAuthenticated, controllers.todos.getAll)
        .post(auth.isAuthenticated, controllers.todos.create);

    app.route('/api/todos/:id')
        .get(auth.isAuthenticated, controllers.todos.getById)
        .put(auth.isAuthenticated, controllers.todos.update)
        .delete(auth.isAuthenticated, controllers.todos.deleteTodo);


    // /partials/user/register => /public/js/user/partials/register.jade
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
