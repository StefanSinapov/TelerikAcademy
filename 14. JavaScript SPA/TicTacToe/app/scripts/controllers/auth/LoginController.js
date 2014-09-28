/* global app */

app.controller('LoginController', ['$rootScope', '$scope', '$location', 'notifier', 'identity', 'auth',
    function ($rootScope, $scope, $location, notifier, identity, auth) {
        'use strict';

        $scope.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user).then(function (success) {
                    if (success) {
                        notifier.success('Successful login!');
                        $rootScope.isLoggedIn = true;
                        $location.path('/');
                    }
                    else {
                        notifier.error('Username/Password combination is not valid!');
                    }
                }, function(reason){
                    notifier.error('Username/Password combination is not valid!');
                });
            }
            else {
                notifier.error('Username and password are required fields!');
            }
        };
    }]);