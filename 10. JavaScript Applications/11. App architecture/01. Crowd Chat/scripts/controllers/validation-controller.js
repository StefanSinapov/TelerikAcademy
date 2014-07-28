define(['jquery'], function ($) {
    'use strict';
    var ValidationController = (function () {
        function isValidUsername(username) {
            var isValid = username && typeof username === 'string' &&
                username.length >= 4 && username.length <= 20;
            return isValid;
        }

        return {
            isValidUsername: isValidUsername
        }
    }());

    return ValidationController;
});