var usersController = require('./usersController');
var statisticsController = require('./statisticsController');
var filesController = require('./filesController');

module.exports = {
    users: usersController,
    statistics: statisticsController,
    files: filesController
};