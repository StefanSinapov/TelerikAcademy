/* global app */

'use strict';

app.controller('MainController', function ($scope, $location, identity, $http, notifier) {
    $scope.identity = identity;

});