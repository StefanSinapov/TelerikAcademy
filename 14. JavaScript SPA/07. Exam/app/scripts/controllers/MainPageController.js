/* global app */

app.controller('MainPageController',
    function HomeController($scope, $rootScope, identity, $location, auth, notifier, appData) {
        'use strict';

        $scope.identity = identity;

        if (identity.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
        }
        else{
            $rootScope.isLoggedIn = false;
        }

        appData
            .drivers.latest()
            .then(function (data) {
                $scope.drivers = data;
            }, function(reason){
                console.log(reason);
                notifier.error('Error getting data (Check your connectivity)');
            });

        appData
            .trips.latest()
            .then(function (data) {
                $scope.trips = data;
            }, function(reason){
                console.log(reason);
                notifier.error('Error getting data (Check your connectivity)');
            });

        appData
            .stats()
            .then(function (data) {
                $scope.stats = data;
            }, function(reason){
                console.log(reason);
                notifier.error('Error getting data (Check your connectivity)');
            });

    });