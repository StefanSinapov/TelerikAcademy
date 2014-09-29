/* global app */

app.controller('CreateTripController',
    function CreateTripController($scope, $location, appData, notifier, identity) {
        'use strict';

        /*$scope.createGame = function(gameName, createForm){
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
         };*/


        //get info
        appData.user.getInfo()
            .then(function (data) {
                if (!data.isDriver) {
                    notifier.error('Only drivers can create trips');
                    $location.path('/trips');
                }
            },
            function (reason) {
                notifier.error(reason.message);
            });

        appData
            .trips.cities()
            .then(function (data) {
                $scope.options = {
                    values: data
                };
            }, function (reason) {
                console.log(reason);
                notifier.error('Error getting data (Check your connectivity)');
            });


        function createTrip(trip, createForm) {



            if (createForm.$valid) {

                if (trip.availableSeats >= 1) {

                    appData.trips.create(trip)
                        .then(function (data) {
                            notifier.success('Game created successfully!');
                            $location.path('/trips');
                        }, function (reason) {
                            notifier.error(reason.message);
                        });
                }
                else {
                    notifier.error('Available seats must be at least 1!');
                }
            }
            else {
                notifier.error('From, To, Available seats and Departure Time are required fields!');
            }
        }

        $scope.createTrip = createTrip;
    });