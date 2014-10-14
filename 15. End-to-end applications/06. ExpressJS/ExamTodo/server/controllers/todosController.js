'use strict';

var encryption = require('../utilities/encryption');
var todos = require('../data/todos');
var Todo = require('mongoose').model('Todo');
var DEFAULT_PAGE_SIZE = 12;

module.exports = {
    getAll: function(req, res, next){
        var title = req.query.title || '';
        var orderBy = req.query.orderBy || '-date';
        var page = Math.max(req.query.page, 1);
        var finished = req.query.finished || false;

        var query = Todo.find()
            .where({ title: new RegExp(title, "i") })
            .sort(orderBy)
            .skip(DEFAULT_PAGE_SIZE * (page - 1))
            .limit(DEFAULT_PAGE_SIZE);

        if (finished) {
            query.where({ isFinished: finished});
        }
        //.select('_id title price')
        query.exec(function (error, collection) {
            if (error) {
                console.error('Error getting todo: ' + error);
            } else {
                res.send(collection);
            }
        });
    },
    create: function(req, res, next){

    },
    getById: function(req, res, next){

    },
    update: function(req, res, next){

    },
    deleteTodo: function(req, res, next){

    }
};