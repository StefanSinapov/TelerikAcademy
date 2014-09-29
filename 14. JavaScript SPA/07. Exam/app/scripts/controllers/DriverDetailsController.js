/* global app */

app.controller('DriverDetailsController',
    function DriverDetailsController($scope, $location, $routeParams, appData, notifier, identity) {
        'use strict';

        appData
            .drivers.getById($routeParams.id)
            .then(function (data) {
                $scope.driver = data;
                $scope.trips = data.trips;
            },
            function (reason) {
                notifier.error(reason.message);
            });

    });
