'use strict';

var mongoose = require('mongoose'),
    Models = require('../data/models');

module.exports = function (config) {
    mongoose.connect(config.databaseConnection);
    var db = mongoose.connection;

    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...');
    });

    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });

    //Models.Message.init();
    Models.Todo.init();
    Models.User.init();


    //data.users.seedUsers();
};