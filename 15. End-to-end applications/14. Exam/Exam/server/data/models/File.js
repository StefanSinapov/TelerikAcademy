'use strict';

var mongoose = require('mongoose');
var File;

module.exports.init = function () {
    var fileSchema = new mongoose.Schema({
        url: { type: String, required: '{PATH} is required' },
        fileName: { type: String, required: '{PATH} is required' },
        date: Date,
        owner: {
            type: mongoose.Schema.Types.ObjectId,
            ref: 'User'
        },
        isPrivate: Boolean
    });

    File = mongoose.model('File', fileSchema);
};