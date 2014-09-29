/* global app */

app.controller('TripDetailsController',
    function TripDetailsController($scope, $location, $routeParams, appData, notifier, identity) {
        'use strict';

        appData
            .trips.getById($routeParams.id)
            .then(function (data) {
                $scope.trip = data;
                console.log(data);
            },
            function (reason) {
                notifier.error(reason.message);
            });

        $scope.joinTrip = function (trip) {

            appData
                .trips.join(trip.id)
                .then(function (data) {
                    $scope.trip = data;
                    notifier.success("Trip successfully joined");
                },
                function (reason) {
                    notifier.error(reason.message);
                });
        };
    });
