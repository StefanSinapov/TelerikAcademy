/* global app */

app.controller('ListUsersController',
    function ListUsersController($scope, appData) {
        "use strict";

        appData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            });
    }
);