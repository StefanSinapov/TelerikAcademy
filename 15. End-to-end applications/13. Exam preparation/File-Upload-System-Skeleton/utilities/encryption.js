var crypto = require('crypto');

module.exports = {
    generateSalt: function () {
        return crypto.randomBytes(128).toString('base64');
    },
    generateHashedPassword: function (salt, pwd) {
        var hmac = crypto.createHmac('sha1', salt);
        return hmac.update(pwd).digest('hex');
    },
    encrypt: function(text, key) {
        var cipher = crypto.createCipher('aes192', key);
        var result = cipher.update(text, 'binary', 'hex');
        result += cipher.final('hex');
        return result;
    },
    decrypt: function(text, key) {
        var decipher = crypto.createDecipher('aes192', key);
        var result = decipher.update(text, 'hex', 'binary');
        result += decipher.final('binary');
        return result;
    }
};