define(['validation-controller', 'user'], function (validationController, User) {
    'use strict';
    var UserController = (function () {
        var $wrapper = $('#wrapper');

        function loadLoginForm() {
            $wrapper.load('views/login-template.html');
            addEventHandlers();
        }

        function addEventHandlers() {
            $wrapper.on('click', '#login-btn', function () {

                var $loginInput = $('#login-name'),
                    $rememberMe = $('#remember-me'),
                    toBeRemembered = $rememberMe.prop('checked'),
                    username = $loginInput.val(),
                    isValidUsername = validationController.isValidUsername(username);

                if (isValidUsername) {
                    User.setName(username, toBeRemembered);
                    $loginInput.parent().removeClass('error');
                    $loginInput.parent().addClass('success');
                    window.location = '#/chat';
                }
                else {
                    $loginInput.parent().removeClass('success');
                    $loginInput.parent().addClass('error');
                }
            });
        }

        return {
            loadLoginFrom: loadLoginForm,
            user: User
        }
    }());

    return UserController;
});