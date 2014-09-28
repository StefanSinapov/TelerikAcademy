/* global app */

app.controller('GameStatusController',
    function GameStatusController($scope, $location, $routeParams, appData, notifier, identity) {
        'use strict';

        var username = identity.getCurrentUser().userName;

        if (!$routeParams.id) {
            $location.path('/');
            return;
        }

        getGameStatus();
        var timer = setInterval(getGameStatus, 2000);

        function getGameStatus() {
            if ($location.path().indexOf('/game/') === -1) {
                clearInterval(timer);
                return;
            }

            appData
                .getGameStatus($routeParams.id)
                .then(function (data) {
                    if ($scope.board !== data.Board || $scope.gameStatus !== data.State) {
                        $scope.gameId = data.Id;
                        $scope.board = data.Board;
                        $scope.gameStatus = data.State;
                        $scope.cursorClass = 'allowed';

                        $scope.hasTwoPlayers = data.FirstPlayerName && data.SecondPlayerName;
                        if ($scope.hasTwoPlayers) {
                            $scope.currentPlayer = username;
                            $scope.firstPlayer = data.FirstPlayerName;
                            $scope.secondPlayer = data.SecondPlayerName;
                        }
                        if (data.FirstPlayerName === username && data.State === 2 ||
                            data.FirstPlayerName !== username && data.State === 1 ||
                            data.State === 0) {
                            $scope.cursorClass = 'disabled';
                        }

                        if ([3, 4, 5].indexOf(data.State) !== -1) {
                            clearInterval(timer);
                            $scope.cursorClass = 'disabled';
                            return;
                        }
                    }
                }, function () {
                    clearInterval(timer);
                    $location.path('/');
                    return;
                });

            $scope.click = function (row, col) {
                if ($scope.currentPlayer === $scope.firstPlayer && $scope.gameStatus === 2 ||
                    $scope.currentPlayer === $scope.secondPlayer && $scope.gameStatus === 1) {
                    return;
                }

                if ($scope.board[row * 3 + col] === '-' && [0, 3, 4, 5].indexOf($scope.gameStatus) === -1) {
                    appData.playGame($scope.gameId, row + 1, col + 1)
                        .then(function () {
                            getGameStatus();
                        }, function (reason) {
                            notifier.error(reason.Message);
                        });
                }
            };
        }
    });