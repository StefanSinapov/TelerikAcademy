var encryption = require('../utilities/encryption');
var fs = require('fs');

var User = require('mongoose').model('User');
var File = require('mongoose').model('File');

var controllerName = 'files';
var encryptionPass = 'ta-file-upload-magic-unicorns-cats';

function getCurrentDate() {
    var date = new Date();
    var dateString = (date.getMonth() + 1) + "_" + date.getDate() + "_" + date.getFullYear().toString().substr(2,2);
    return dateString;
}

var uploadedFiles;

module.exports = {
    getUpload: function(req, res, next) {
        res.render(controllerName + '/upload');
    },
    postUpload: function(req, res, next) {
        uploadedFiles = undefined;
        req.pipe(req.busboy);

        var files = [];

        req.busboy.on('file', function (fieldname, file, filename) {
            var url = req.user.username + '/' + getCurrentDate() + '/' + filename;
            var cipheredUrl = encryption.encrypt(url, encryptionPass);
            files[fieldname] = files[fieldname] || {};
            files[fieldname].fileName = filename;
            files[fieldname].url = cipheredUrl;

            var path = __dirname + '/../file_uploads/' + url;

            var userNamePath = __dirname + '/../file_uploads/' + req.user.username;
            var datePath = userNamePath + '/' + getCurrentDate();

            if (fs.existsSync(path)) {
                fs.unlinkSync(path);
            }

            fs.mkdir(userNamePath, 0777, function(err) {
                if (err && err.code != 'EEXIST') console.log(err);
                else {
                    fs.mkdir(datePath, 0777, function(err) {
                        if (err && err.code != 'EEXIST') console.log(err);
                        else {
                            var fstream = fs.createWriteStream(path);
                            file.pipe(fstream);
                        }
                    });
                }
            });
        });

        req.busboy.on('field', function(fieldname, val) {
            var file = fieldname.substr(0, fieldname.indexOf('private'));
            files[file] = files[file] || {};
            files[file].private = val;
        });

        req.busboy.on('finish', function() {
            var count = 0;
            for(var file in files) {
                new File({
                    url: file.url,
                    private: file.private
                })
                .save(function() {
                    count++;
                    if (count == Object.keys(files).length) {
                        uploadedFiles = files;
                        res.redirect('/upload/links');
                    }
                });
            };
        });
    },
    getLinks: function(req, res, next) {
        if (!uploadedFiles) {
            res.redirect('/');
        }
        else {
            var viewFiles = [];

            for(var file in uploadedFiles) {
                viewFiles.push(uploadedFiles[file]);
            }

            uploadedFiles = undefined;

            res.render(controllerName + '/links', {files: viewFiles});
        }
    },
    download: function(req, res, next) {
        var cipher = req.params.id;
        var path = encryption.decrypt(cipher, encryptionPass);

        var parts = path.split('/');
        File.find({url: path}).exec(function(err, file) {
            if (file.private) {
                User.find({username: parts[0]}).exec(function(err, user) {
                    if (req.user.username == user.username) {
                        res.download(__dirname + '/../file_uploads/' + path);
                    }
                });
            }
            else {
                res.download(__dirname + '/../file_uploads/' + path);
            }
        });
    }
};