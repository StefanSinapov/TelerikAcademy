/* global app */

'use strict';

app.controller('RegisterController', function RegisterController($scope, $location, auth, notifier) {
    $scope.register = function (user, singUpForm) {
        if (singUpForm.$valid) {

            if (user.password === user.confirmPassword) {

                auth.register(user)
                    .then(function (data) {
                        notifier.success('Registration successful!');
                        $location.path('/');
                    }, function (reason) {
                        if (reason) {
                            notifier.error('Error creating account: ' + reason.message || reason);
                        }
                        else {
                            notifier.error("The request is invalid. (Check your connectivity)");
                        }
                    });
            }
            else {
                notifier.error('Password and confirm password must be the same!');
            }
        }
        else {
            notifier.error('First name, Last name, Username and password are required fields.');
        }
    };
});