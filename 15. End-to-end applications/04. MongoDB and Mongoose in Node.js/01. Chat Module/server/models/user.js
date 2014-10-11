'use strict';

var mongoose = require('mongoose');
var User;

var userSchema = mongoose.Schema({
    username: { type: String, require: '{PATH} is required', unique: true },
    pass: { type: String, require: '{PATH} is required' }
});

User = mongoose.model('User', userSchema);

module.exports = {
    seedUsers: function () {
        User.find({}).exec(function (err, collection) {
            if (err) {
                console.log('Error finding users: ' + err);
                return;
            }

            if (collection.length === 0) {
                User.create({username: 'Pesho', pass: '123456'});
                User.create({username: 'Gosho', pass: 'qwerty'});
                console.log('Users added to database...');
            }
        });
    }
};