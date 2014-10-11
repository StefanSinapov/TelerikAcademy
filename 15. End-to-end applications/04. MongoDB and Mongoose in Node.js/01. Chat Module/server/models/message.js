'use strict';

var mongoose = require('mongoose');
var Message;

var messageSchema = mongoose.Schema({
    from: {
        type: mongoose.Schema.ObjectId,
        rel: 'User',
        required: '{PATH} is required'
    },
    to: {
        type: mongoose.Schema.ObjectId,
        rel: 'User',
        required: '{PATH} is required'
    },
    text: String
});

Message = mongoose.model('Message', messageSchema);

module.exports.seedMessages = function () {
    Message.find({}).exec(function (err, collection) {
        if (err) {
            console.log('Error during seeding messages: ' + err);
        }
        else {
            if (collection.length === 0) {

                var User = mongoose.model('User');

                User.find({}).exec(function (err, userCollection) {

                    if (err) {
                        console.log('Cannot find users: ' + err);
                    }

                    var firstUser = userCollection[0];
                    var secondUser = userCollection[1];

                    Message.create({from: firstUser, to: secondUser, text: "Hey Pesho how are you?"});
                    Message.create({from: secondUser, to: firstUser, text: "I'm fine, and you?"});

                    console.log("Messages seed to database");
                });
            }
        }
    });
};