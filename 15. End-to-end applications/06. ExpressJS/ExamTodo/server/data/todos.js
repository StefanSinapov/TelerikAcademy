'use strict';

var Todo = require('mongoose').model('Todo');

module.exports = {
    create: function(item, callback){
        Todo.create(item, callback);
    },
    deleteTodo: function(item, callback){

    },

    seedTodos: function(){
        //TODO: add todos seed
    }
};