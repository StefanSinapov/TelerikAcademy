/* global app */

'use strict';

app.controller('NavController', function($scope, $location, notifier, identity, auth) {
    $scope.identity = identity;

    $scope.logout = function() {
        auth.logout().then(function() {
            notifier.success('Successful logout!');
            $location.path('/');
        });
    };
});