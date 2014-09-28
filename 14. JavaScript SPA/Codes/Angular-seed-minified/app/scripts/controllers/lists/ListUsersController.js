/* global app */

app.controller('ListUsersController',
    function ListUsersController($scope, appData, notifier) {
        "use strict";

        appData
            .getUsers()
            .then(function (data) {
                $scope.users = data;
            }, function(reason){
				console.log(reason);
				notifier.error('Error getting data (Check your connectivity)');
			});
    }
);