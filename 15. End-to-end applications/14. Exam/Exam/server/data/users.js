'use strict';

var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback){
        User.create(user, callback);
    },
    findOne: function(id, callback){
        User.findOne({_id: id}, callback);
    },
    remove: function(id, callback){
        User
            .findOne({ _id: id })
            .remove()
            .exec(callback);
    },
    getCount: function(callback){
        User.count({}, callback);
    }
};