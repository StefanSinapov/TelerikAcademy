var mongoose = require('mongoose');

module.exports.init = function() {
    var fileSchema = mongoose.Schema({
        url: String,
        private: Boolean
    });

    var File = mongoose.model('File', fileSchema);
};