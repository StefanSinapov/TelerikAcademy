/* global app */

'use strict';

app.controller('MainController', function ($scope, $location, identity) {
    $scope.identity = identity;
});