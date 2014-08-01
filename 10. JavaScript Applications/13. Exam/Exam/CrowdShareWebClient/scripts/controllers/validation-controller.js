define(['jquery'], function ($) {
    'use strict';
    var ValidationController = (function () {
        function isValidUsername(username) {
            var isValid = username && typeof username === 'string' &&
                username.length > 5 && username.length <= 40;
            return isValid;
        }

        return {
            isValidUsername: isValidUsername
        }
    }());

    return ValidationController;
});