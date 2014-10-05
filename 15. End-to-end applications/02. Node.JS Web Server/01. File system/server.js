'use strict';

var http = require('http');
var fs = require('fs');
var formidable = require('formidable');
var util = require('util');
var port = 3000;

var storedFile;
var originalFileName;


var server = http.createServer(function (req, res) {
    switch (req.url) {
        case '/upload':
            uploadFile(req, res);
            break;

        case '/download':
            downloadFile(req, res);
            break;

        default:
            res.writeHead(200, {'content-type': 'text/html'});
            res.write(showUploadForm());
            res.end();
            break;
    }
});

server.listen(port);
console.log('Server running on ' + port);

function uploadFile(req, res) {
    var form = new formidable.IncomingForm();
    form.uploadDir = './files/';
    form.encoding = 'utf-8';
    form.keepExtensions = true;

    form.parse(req, function (err, fields, files) {
        res.writeHead(200, { 'content-type': 'text/html' });
    });

    form.on('fileBegin', function (name, file) {
        file.path = __dirname + '/files/' + file.name;
    });

    form.on('progress', function (bytesReceived, bytesExpected) {
        var percent_complete = (bytesReceived / bytesExpected) * 100;
        console.log(percent_complete.toFixed(2));
    });

    form.on('error', function (err) {
        util.error(err);
    });

    form.on('end', function (fields, files) {
        /* Temporary location of our uploaded file */
        var temp_path = this.openedFiles[0].path;
        /* The file name of the uploaded file */
        var file_name = this.openedFiles[0].name;
        /* Location where we want to copy the uploaded file */

        res.write('<h2>Successfull upload.</h2>');
        res.write('<a href="/download">Download</a>');
        storedFile = temp_path;
        originalFileName = file_name;
        res.end();
    });
}

function downloadFile(req, res) {
    var stat = fs.statSync(storedFile);
    res.writeHead(200, {
        'Content-Length': stat.size
    });
    var readStream = fs.createReadStream(storedFile);
    readStream.pipe(res);
}


function showUploadForm() {
    return '<form action="/upload" enctype="multipart/form-data" method="post">' +
        '<input type="file" name="upload" multiple="multiple"><br>' +
        '<input type="submit" value="Upload">' +
        '</form>';
}