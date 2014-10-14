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
        todos: [mongoose.model('Todo').schema]
    });

    userSchema.method({
        authenticate: function(password) {
            return encryption.generateHashedPassword(this.salt, password) === this.hashPass;
        }
    });

    var User = mongoose.model('User', userSchema);
};