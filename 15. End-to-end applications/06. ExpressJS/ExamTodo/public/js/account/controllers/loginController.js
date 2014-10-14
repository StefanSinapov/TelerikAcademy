/* global app */

'use strict';

app.controller('LoginController', function LoginController($scope, $location, notifier, identity, auth) {
    $scope.identity = identity;

    $scope.login = function (user, loginForm) {
        if (loginForm.$valid) {
            auth.login(user).then(function (success) {
                    if (success) {
                        notifier.success('Successful login!');
                        $location.path('/');
                    }
                    else {
                        notifier.error('Username/Password combination is not valid!');
                    }
                },
                function (reason) {
                    console.log(reason);
                    notifier.error('Username/Password combination is not valid!');
                });
        }
        else {
            notifier.error('Username and password are required fields!');
        }
    };
});