var path = require('path');
var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        rootPath: rootPath,
        databaseConnection: 'mongodb://localhost:27017/examtodo',
        port: process.env.PORT || 3000
    },
    production: {
        rootPath: rootPath,
        databaseConnection: 'admin:123456q@ds039950.mongolab.com:39950/examtodo',
        port: process.env.PORT || 3030
    }
};