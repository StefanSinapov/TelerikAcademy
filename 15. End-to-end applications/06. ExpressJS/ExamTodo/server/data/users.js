'use strict';

var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback){
        User.create(user, callback);
    },
    find: function(id, callback){
        User.findOne({_id: id}, callback);
    },
    deleteUser: function(id, callback){
        User
            .findOne({ _id: id })
            .remove()
            .exec(callback);
    },
    seedUsers: function(){
        //TODO: add users seed
    }
};