'use strict';

var File = require('mongoose').model('File');

module.exports = {
    init: function () {
        File.init();
    },
    create: function (file, callback) {
        File.create(file, callback);
    },
    findOne: function (id, callback) {
        File.findOne({_id: id}, callback);
    },
    remove: function (id, callback) {
        File
            .findOne({ _id: id })
            .remove()
            .exec(callback);
    },
    getCount: function(callback){
        File.count({}, callback);
    },
    addFiles: function addFiles(files){
        for(var file in files) {
            File.create(files[file]);
        }
    }
};