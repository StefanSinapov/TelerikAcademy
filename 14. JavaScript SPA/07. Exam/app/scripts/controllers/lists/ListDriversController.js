/* global app */

app.controller('ListDriversController',
    function ListDriversController($scope, appData, notifier) {
        "use strict";

        /*  appData
         .getUsers()
         .then(function (data) {
         $scope.users = data;
         }, function(reason){
         console.log(reason);
         notifier.error('Error getting data (Check your connectivity)');
         });*/

        $scope.page = 1;
        $scope.username = '';
        $scope.btnDisabled = 'disabled';


        function nextPage(page, username) {

            page++;
            if (page >= 1) {
                $scope.btnDisabled = '';
            }
            $scope.page = page;
            filter(page, username);
        }

        function previousPage(page, username) {
            page--;
            if (page === 1) {
                $scope.btnDisabled = 'disabled';
            }
            $scope.page = page;
            filter(page, username);

        }

        function filter(page, username) {

            appData
                .drivers.filter(page, username)
                .then(function (data) {
                    $scope.drivers = data;
                }, function (reason) {
                    console.log(reason);
                    notifier.error('Error getting data (Check your connectivity)');
                });
        }

        $scope.nextPage = nextPage;
        $scope.filter = filter;
        $scope.previousPage = previousPage;
    }
);