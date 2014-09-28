/* global app */

app.controller('CreateGameController',
    function CreateGameController($scope, $location, appData, notifier) {
        'use strict';

        $scope.createGame = function(gameName, createForm){
            if (createForm.$valid) {
                appData.createGame(gameName)
                    .then(function () {
                        notifier.success('Game created successfully!');
                        $location.path('/');
                    });
            }
            else{
                notifier.error('Name is required!');
            }
        };
    });