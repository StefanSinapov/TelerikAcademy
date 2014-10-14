'use strict';

var auth = require('./auth'),
    controllers = require('../controllers'),
    events = require('../data/events');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.users.postProfile);

    app.get('/events/create', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/events/create', auth.isAuthenticated, controllers.events.postCreate);

    app.get('/events/active', auth.isAuthenticated, controllers.events.getActive);
    app.get('/events/past', auth.isAuthenticated, controllers.events.getPast);


    app.get('/events/:id', auth.isAuthenticated, controllers.events.getEventById);
    app.post('/events/:id', auth.isAuthenticated, controllers.events.postEventById);

    app.post('/events/:id/join', auth.isAuthenticated, controllers.events.joinEvent);




//    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
//    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
//
//    app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);
//
//    app.get('/files/download/:id', controllers.files.download);

    app.get('/', function(req, res) {
        events.getCount(function(err, count){
            res.render('index', {count: count});
        });
    });

    app.get('*', function(req, res) {
        res.render('index');
    });
};