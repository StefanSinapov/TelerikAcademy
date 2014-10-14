'use strict';

var mongoose = require('mongoose');
var Todo;

module.exports.init = function () {
    var todoSchema = new mongoose.Schema({
        title: { type: String, required: '{PATH} is required' },
        content: { type: String, required: '{PATH} is required' },
        date: Date,
        owner: {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        },
        isFinished: Boolean,
        attachments: [String]
    });

    Todo = mongoose.model('Todo', todoSchema);
};