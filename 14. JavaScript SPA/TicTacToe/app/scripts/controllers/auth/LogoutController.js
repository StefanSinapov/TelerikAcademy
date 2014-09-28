/* global app */

app.controller('LogoutController',
    function LogoutController($rootScope, $scope, $resource, $location, auth, notifier) {
        'use strict';
        $scope.logout = function () {
            auth.logout()
                .then(function () {
                    notifier.success('Successful logout!');
                    $rootScope.isLoggedIn = false;
                    $location.path('/');
                });
        };
    });