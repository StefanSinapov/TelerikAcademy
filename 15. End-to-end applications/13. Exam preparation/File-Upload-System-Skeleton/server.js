var express = require('express');

var environment = process.env.NODE_ENV || 'development';
var config = require('./config/config')[environment];

var app = express();

require('./config/express')(app, config);
require('./config/mongoose')(config);
require('./config/passport')();
require('./config/routes')(app);

app.listen(config.port);
console.log('Express server listening on port ' + config.port);