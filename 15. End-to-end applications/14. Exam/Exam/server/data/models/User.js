'use strict';

var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');

var User;

module.exports.init = function() {
    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true },
        firstName: { type: String, require: '{PATH} is required' },
        lastName: { type: String, require: '{PATH} is required' },
        salt: String,
        hashPass: String,
        roles: [String],
        files: [mongoose.model('File').schema],
        points: Number
    });

    userSchema.method({
        authenticate: function(password) {
            return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
        }
    });

    User = mongoose.model('User', userSchema);
};

module.exports.seedUsers = function(){

    User.find({}).exec(function (error, collection) {
        if (error) {
            console.log('Cannot find users: ' + error);
            return;
        }

        if (collection.length === 0) {
            var salt;
            var hashedPwd;

            // Admin
            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'admin');
            User.create({username: 'admin', salt: salt, hashPass: hashedPwd, roles: ['admin'],
                firstName: 'Peter', lastName: 'Petrov'});

            // Standard user
            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'user');
            User.create({username: 'user', salt: salt, hashPass: hashedPwd, roles: ['user'], points: 1,
                firstName: 'Ivan', lastName: 'Ivanov'});

            console.log('Users added to database...');
        }
    });
};