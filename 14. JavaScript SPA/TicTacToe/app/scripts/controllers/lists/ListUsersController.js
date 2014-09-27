/* global ticTacToeApp */

ticTacToeApp.controller('ListUsersController',
    function ListUsersController($scope, ticTacToeData) {
        "use strict";

        ticTacToeData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            });
    }
);