/* global ticTacToeApp */

ticTacToeApp.controller('LogoutController',
    function LogoutController($rootScope, $scope, $resource, $location, ticTacToeData, auth) {
        'use strict';

        $scope.logout = function () {
            auth.logout();
            $rootScope.isLoggedIn = false;
            $location.path('/login');
            return;
        };
    });