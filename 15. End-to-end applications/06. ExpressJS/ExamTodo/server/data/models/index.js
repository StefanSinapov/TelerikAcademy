'use strict';

var UserModel = require('../models/User'),
    TodoModel = require('./Todo');

module.exports = {
    User : UserModel,
    Todo : TodoModel
};