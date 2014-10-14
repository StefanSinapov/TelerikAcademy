/* global app */

'use strict';

app.controller('MainController', function ($scope, $location, identity, $http, notifier) {
    $scope.identity = identity;

    $http.get('/api/statistics')
        .success(function(data){
            $scope.statistics = data;
        })
        .error(function(error){
            notifier.error('Failed to load statistics: ' + error.message || error);
        });
});