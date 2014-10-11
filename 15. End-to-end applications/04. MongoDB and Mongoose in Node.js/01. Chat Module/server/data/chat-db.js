'use strict';

require('../models/user');
require('../models/message');

var mongoose = require('mongoose');
var User = mongoose.model('User');
var Message = mongoose.model('Message');

module.exports = {
    registerUser: function (user) {
        User.create(user);
    },
    sendMessage: function (msg) {
        User.findOne({username: msg.from}).exec(function (err, fromUser) {
            if (err) {
                console.log("Cannot find from user: " + err);
            }

            User.findOne({username: msg.to}).exec(function (err, toUser) {
                if (err) {
                    console.log('Cannot find \'to\' user: ' + err);
                }

                Message.create({from: fromUser, to: toUser, text: msg.text});
            });
        });
    },
    getMessages: function (params, callback) {
        User.findOne({username: params.with}).exec(function (err, firstUser) {
            if (err) {
                console.log('Cannot find user: ' + err);
            }

            User.findOne({username: params.and}).exec(function (err, secondUser) {
                if (err) {
                    console.log('Cannot find user: ' + err);
                }

                Message.find({from: firstUser, to: secondUser}).exec(function (err, messages) {
                    if (err) {
                        console.log('Cannot find messages: ' + err);
                        return;
                    }

                    callback(messages);
                });
            });
        });
    }
};