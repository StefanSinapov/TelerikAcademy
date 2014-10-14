'use strict';

var encryption = require('../utilities/encryption');
var files = require('../data/files');
var uploading = require('../utilities/uploading');

var CONTROLLER_NAME = 'files';
var URL_PASSWORD = 'asdfkklhgsakdjlfhlk';

var uploadedFiles = [];

function getDate() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1;

    var yyyy = today.getFullYear();
    if(dd < 10){
        dd='0'+dd;
    }

    if(mm < 10){
        mm= '0'+mm;
    }

    return dd + '-' + mm + '-' + yyyy;
}

module.exports = {
    upload: function (req, res, next) {
        req.pipe(req.busboy);

        var username = req.user.username;

        req.busboy.on('file', function (fieldname, file, filename) {
            var fileNameHashed = encryption.generateHashedPassword(encryption.generateSalt(), filename);
            var currentDate = getDate();
            var path = '/' + username + '/' + currentDate + '/';
            var url = path + fileNameHashed;
            var urlEncrypted = encryption.encrypt(url, URL_PASSWORD);
            uploading.saveFile(file, path, fileNameHashed);

            uploadedFiles[username] = uploadedFiles[username] || [];

            uploadedFiles[username][fieldname] = uploadedFiles[username][fieldname] || {};
            var dbFile = uploadedFiles[username][fieldname];
            dbFile.url = urlEncrypted;
            dbFile.fileName = filename;
            dbFile.owner = req.user._id;
            dbFile.date = currentDate;
        });

        req.busboy.on('field', function(fieldname, val) {
            var index = fieldname.split('_')[1];
            uploadedFiles[username] = uploadedFiles[username] || [];
            uploadedFiles[username]['file_' + index] = uploadedFiles[username]['file_' + index] || {};
            var dbFile = uploadedFiles[username]['file_' + index];
            dbFile.isPrivate = !!val;
        });

        req.busboy.on('finish', function() {
            files.addFiles(uploadedFiles[username]);
            res.json({message: 'files saved successfully'});
            //res.redirect('/');
        });
    },
    getResults: function(req, res, next){
        var resultFiles = uploadedFiles[req.user.username];

        if (!resultFiles) {
           res.redirect('#/files/upload');
        }
        else{
            var files = [];
            for(var file in resultFiles) {
                files.push(resultFiles[file]);
            }

            uploadedFiles[req.user.username] = undefined;

            res.send(files);
        }
    },
    getAllFiles: function (req, res, next) {

    },
    shareFile: function(req, res, next){

    },
    download: function (req, res, next) {
        var url = req.params.id;
        console.log(url);
        var decryptedUrl = encryption.decrypt(url, URL_PASSWORD);

        res.download(__dirname + '/../../files' + decryptedUrl);
    }
};