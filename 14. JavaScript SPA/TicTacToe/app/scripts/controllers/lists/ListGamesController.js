/* global app */

app.controller('ListGamesController',
    function ListGamesController($scope, $location, notifier, identity, appData) {
        'use strict';

        var getMyGames = function () {
            appData.getMyGames()
                .then(function (data) {
                    $scope.myGames = data;
                    $scope.firstPlayer = data.firstPlayer;
                    $scope.currentPlayer = identity.getCurrentUser().userName;
                });
        };

        var getAvailableGames = function () {
            appData.getAvailableGames()
                .then(function (data) {
                    $scope.availableGames = data;
                    $scope.firstPlayer = data.firstPlayer;
                    $scope.currentPlayer = identity.getCurrentUser().userName;
                });
        };

        var getJoinedGames = function () {
            appData.getJoinedGames()
                .then(function (data) {
                    $scope.joinedGames = data;
                    $scope.firstPlayer = data.firstPlayer;
                    $scope.currentPlayer = identity.getCurrentUser().userName;
                });
        };

        getMyGames();
        getAvailableGames();
        getJoinedGames();

        $scope.joinGame = function (gameId) {
            appData
                .joinGame(gameId)
                .then(function () {
                    notifier.success("Successfully joined game!");
                    getJoinedGames();
                    getAvailableGames();
                }, function () {
                    notifier.error("Ops something goes wrong.");
                });
        };

        $scope.playGame = function (gameId) {
            $location.path('/game/' + gameId);
        };

        $scope.refreshAvailableGames = getAvailableGames;
        $scope.refreshJoinedGames = getJoinedGames;
        $scope.refreshMyGames = getMyGames;
    });