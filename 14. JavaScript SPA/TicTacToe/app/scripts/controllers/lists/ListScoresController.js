/* global app */

app.controller('ListScoresController',
    function ListUsersController($scope, appData) {
        "use strict";

        appData
            .getScores()
            .then(function (data) {
                $scope.users = data;
            });
    }
);