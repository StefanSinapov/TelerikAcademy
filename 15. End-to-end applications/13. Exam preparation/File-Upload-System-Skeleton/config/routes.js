var auth = require('./auth');
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/', function(req, res) {
        res.render('index');
    });

    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login, controllers.users.postLogin);

    app.get('/logout', auth.logout, controllers.users.logout);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    app.get('/upload/links', auth.isAuthenticated, controllers.files.getLinks);
    app.get('/files/download/:id', controllers.files.download);

    app.use(function(req, res, next) {
        if (req.session.errorMessage || app.locals.errorMessage) {
            delete app.locals.errorMessage;
            delete req.session.errorMessage;
        }

        next();
    });

    app.get('*', function(req, res) {
        res.redirect('/');
    });
};