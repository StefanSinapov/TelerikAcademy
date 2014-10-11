'use strict';

// Module dependencies.
var express = require('express'),
    morgan = require('morgan'),
    errorhandler = require('errorhandler'),
    chat = require('./server/data/chat-db');

var app = module.exports = exports.app = express();

app.locals.siteName = "ChatModule";

// Connect to database
var db = require('./server/config/db');

app.use(express.static(__dirname + '/public'));


var env = process.env.NODE_ENV || 'development';

if ('development' === env) {
    app.use(morgan('dev'));
    app.use(errorhandler({
        dumpExceptions: true,
        showStack: true
    }));
}

// Start server
var port = process.env.PORT || 3000;
app.listen(port, function () {
    console.log('Express server listening on port %d in %s mode', port, app.get('env'));
});


//inserts a new user records into the DB
chat.registerUser({username: 'DonchoMinkov', pass: '123456q'});
chat.registerUser({username: 'NikolayKostov', pass: '123456q'});

//inserts a new message record into the DB
//the message has two references to users (from and to)
chat.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});
//returns an array with all messages between two users
chat.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov'
}, function (messages) {
    if (messages.length) {
        console.log('-----Messages-----');
        messages.map(function (msg) {
            console.log('message: ' + msg.text);
        });
    }
    else {
        console.log('Cannot found messages between this users');
    }
});


chat.getMessages({
    with: 'Pesho',
    and: 'Gosho'
}, function (messages) {
    if (messages.length) {
        console.log('-----Messages---');
        messages.map(function (msg) {
            console.log('message: ' + msg.text);
        });
    }
    else {
        console.log('Cannot found messages between this users');
    }
});

