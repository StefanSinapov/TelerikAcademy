/* global app */

app.controller('RegistrationController', ['$scope', '$location', 'auth', 'notifier', 'appData',
    function ($scope, $location, auth, notifier, appData) {
        'use strict';
        $scope.register = function (user, registerForm) {

            if (registerForm.$valid) {

                if (user.password === user.confirmPassword) {

                    appData.user.register(user)
                        .then(
                            function (data) {
                                notifier.success('Registration successful!');
                                $location.path('/');
                            },
                            function (reason) {
                                if (reason) {
                                    if(reason.modelState) {
                                        if (reason.modelState[''][0]) {
                                            notifier.error(reason.modelState[''][0]);
                                        }
                                        else {
                                            notifier.error("The request is invalid.");
                                        }
                                    }
                                    else{
                                        if(reason.message){
                                            notifier.error(reason.message);
                                        }
                                    }
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
                if (user.isDriver) {
                    notifier.error('Username, password and car name are required fields!');
                }
                else {
                    notifier.error('Username and password are required fields!');
                }
            }
        };
    }]);
