var express = require('express');

var env = process.env.NODE_ENV || 'development';
console.log('process.env.NODE_ENV : ' + process.env.NODE_ENV);

var app = express();
var config = require('./server/config/config')[env];

require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);
require('./server/config/passport')();
require('./server/config/routes')(app);


var server = app.listen(config.port);
console.log("NODE_ENV = " + env);
console.log("Server running on port: " + config.port);

module.exports = {
    app: app,
    port: config.port,
    host: 'http://localhost'
};