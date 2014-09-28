/* global app */

app.controller('RegistrationController', ['$scope', '$location', 'auth', 'notifier',
    function ($scope, $location, auth, notifier) {
        'use strict';
        $scope.register = function (user, registerForm) {
            if (registerForm.$valid) {

                if (user.password === user.confirmPassword) {
                    auth.register(user)
                        .then(function (data) {
                            notifier.success('Registration successful!');
                            $location.path('/');
                        }, function (reason) {
                            if (reason.ModelState[''][0]) {
                                notifier.error(reason.ModelState[''][0]);
                            }
                            else {
                                notifier.error("The request is invalid.");
                            }
                        });
                }
                else {
                    notifier.error('Password and confirm password must be the same!');
                }
            }
            else {
                notifier.error('Username and password are required fields!');
            }
        };
    }]);
