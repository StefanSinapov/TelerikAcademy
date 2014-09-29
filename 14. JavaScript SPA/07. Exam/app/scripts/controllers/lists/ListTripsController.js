/* global app */

app.controller('ListTripsController',
    function ListTripsController($scope, appData, notifier, identity) {
        "use strict";

        if (identity.isAuthenticated()) {
            appData
                .trips.cities()
                .then(function (data) {
                    $scope.fromCities = {
                        name: 'From',
                        values: data
                    };
                    $scope.toCities = {
                        name: 'To',
                        values: data
                    };
                }, function (reason) {
                    console.log(reason);
                    notifier.error('Error getting data (Check your connectivity)');
                });


            $scope.orderBy = {
                name: 'Sort by',
                values: ['Date', 'Driver', 'Seats']
            };

            $scope.order = {
                name: 'Order By',
                values: ['asc', 'desc']
            };


            $scope.filterOptions = {
                page: 1,
                orderBy: 'Date',
                orderType: 'asc',
                from: '',
                to: '',
                finished: false,
                onlyMine: false
            };

            filter($scope.filterOptions);

            $scope.btnDisabled = 'disabled';


            $scope.isLoggedInAndInTab = true;
        }
        else {
            $scope.isLoggedInAndInTab = false;
        }


        function nextPage(filterOptions) {

            filterOptions.page++;
            if (filterOptions.page >= 1) {
                $scope.btnDisabled = '';
            }
            filter(filterOptions);
        }

        function previousPage(filterOptions) {

            filterOptions.page--;
            if (filterOptions.page === 1) {
                $scope.btnDisabled = 'disabled';
            }

            filter(filterOptions);

        }

        function filter(filterOptions) {
            appData.trips.filter(filterOptions)
                .then(function (data) {
                    $scope.trips = data;
                }, function (error) {
                    notifier.error("Something went wrong");
                });
        }

        $scope.filter = filter;
        $scope.previousPage = previousPage;
        $scope.nextPage = nextPage;
    }
);