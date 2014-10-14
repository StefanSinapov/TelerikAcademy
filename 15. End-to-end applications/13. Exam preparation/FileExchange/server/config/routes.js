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


    // Files
    app.route('/api/files')
        .post( auth.isAuthenticated, controllers.files.upload)
        .get( auth.isAuthenticated, controllers.files.getAllFiles);

    app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);

    app.route('/api/files/:id')
        .put(auth.isAuthenticated, controllers.files.shareFile)
        .get(controllers.files.download);

    // Statistics
    app.get('/api/statistics/', controllers.statistics.getStatistics);

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
