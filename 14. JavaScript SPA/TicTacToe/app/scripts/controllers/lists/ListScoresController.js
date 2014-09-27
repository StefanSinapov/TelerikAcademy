/* global ticTacToeApp */

ticTacToeApp.controller('ListScoresController',
    function ListUsersController($scope, ticTacToeData) {
        "use strict";

        ticTacToeData
            .getScores()
            .then(function (data) {
                $scope.users = data;
            });
    }
);