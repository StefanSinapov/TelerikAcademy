'use strict';

var UserModel = require('../models/User'),
    FileModel = require('../models/File');

module.exports = {
    User : UserModel,
    File : FileModel
};