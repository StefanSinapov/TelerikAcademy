'use strict';

var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');
var User;
module.exports.init = function () {
    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true },
        email: { type: String, require: '{PATH} is required' },
        firstName: { type: String, require: '{PATH} is required' },
        lastName: { type: String, require: '{PATH} is required' },
        profilePicture: { type: String, require: '{PATH} is required' },
        phoneNumber: { type: String },
        facebookProfile: String,
        twitterProfile: String,
        linkedInProfile: String,
        googlePlusProfile: String,
        salt: String,
        hashPass: String,
        eventPoints: {
            organization: { type: String, require: '{PATH} is required' },
            venue: { type: String, require: '{PATH} is required' }
        },
        initiatives: [
            {
                name: String,
                season: String
            }
        ]
    });

    userSchema.method({
        authenticate: function (password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    User = mongoose.model('User', userSchema);
};

module.exports.seedUsers = function () {

    User.find({}).exec(function (error, collection) {
        if (error) {
            console.log('Cannot find users: ' + error);
            return;
        }

        if (collection.length === 0) {
            var salt;
            var hashedPwd;

            // Standard user
            salt = encryption.generateSalt();
            hashedPwd = encryption.generateHashedPassword(salt, 'user');
            User.create({username: 'user', email: 'user@user.com', salt: salt, hashPass: hashedPwd, eventPoints: {
                venue: 1,
                organization: 0
            }, firstName: 'Ivan', lastName: 'Ivanov', phoneNumber: '0899819384',
                initiatives: {
                    name: 'Software Academy',
                    season: "2010"
                },
                profilePicture: 'default-avatar.jpg'});

            console.log('Users added to database...');
        }
    });
};
