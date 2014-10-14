'use strict';

var mongoose = require('mongoose');

module.exports.init = function () {
    var eventSchema = mongoose.Schema({
        title: { type: String, require: '{PATH} is required' },
        description: { type: String, require: '{PATH} is required' },
        location: { type: String},
        category: { type: String, require: '{PATH} is required' },
        date: Date,
        type: {
            isPublic: Boolean,
            initiative: { type: String },
            season: { type: String }
        },
        creator: {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        },
        comments: [{
            username: String,
            content: String
        }],
        participants: [{
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        }]
    });

    var Event = mongoose.model('Event', eventSchema);
};


// "Software Academy", "Algo Academy", "School Academy" and "Kids Academy".
// Started 2010", "Started 2011", "Started 2012" and "Started 2013"